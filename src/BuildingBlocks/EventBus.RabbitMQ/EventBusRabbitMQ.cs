﻿using EventBus.Base;
using EventBus.Base.Events;
using Newtonsoft.Json;
using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.RabbitMQ
{
    public class EventBusRabbitMQ : BaseEventBus
    {
        RabbitMQPersistenceConnection persistenceConnection;
        private readonly IConnectionFactory connectionFactory;
        private readonly IModel consumerChannel;
        public EventBusRabbitMQ(EventBusConfig config, IServiceProvider serviceProvider) : base(config, serviceProvider)
        {
            if (config.Connection != null)
            {
                var connJson = JsonConvert.SerializeObject(eventBusConfig.Connection, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                });
                connectionFactory = JsonConvert.DeserializeObject<ConnectionFactory>(connJson);
            }
            else
            {
                connectionFactory = new ConnectionFactory() { HostName = config.Host, UserName = "guest", Password = "guest", Port = 5672 };
            }
            persistenceConnection = new RabbitMQPersistenceConnection(connectionFactory, config.ConnectionRetryCount);
            consumerChannel = CreateConsumerChannel();
            SubsManager.OnEventRemoved += SubsManager_OnEventRemoved;
        }

        private void SubsManager_OnEventRemoved(object? sender, string eventName)
        {
            eventName = ProcessEventName(eventName);
            if (!persistenceConnection.IsConnected)
            {
                persistenceConnection.TryConnect();
            }

            consumerChannel.QueueUnbind(queue: eventName,
                                      exchange: eventBusConfig.DefaultTopicName,
                                      routingKey: eventName);
            if (SubsManager.IsEmpty)
            {
                consumerChannel.Close();
            }
        }

        public override void Publish(IntegrationEvent @event)
        {
            if (!persistenceConnection.IsConnected)
            {
                persistenceConnection.TryConnect();
            }

            var policy = Policy.Handle<BrokerUnreachableException>()
                              .Or<SocketException>()
                              .WaitAndRetry(eventBusConfig.ConnectionRetryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
                              {
                                  //logging
                              });
            var eventName = @event.GetType().Name;
            eventName = ProcessEventName(eventName);
            consumerChannel.ExchangeDeclare(exchange: eventBusConfig.DefaultTopicName, type: "direct");

            var message = JsonConvert.SerializeObject(@event);
            var body = Encoding.UTF8.GetBytes(message);

            policy.Execute(() =>
            {
                var properties = consumerChannel.CreateBasicProperties();
                properties.DeliveryMode = 2; //Sürekli

                consumerChannel.QueueDeclare(queue: GetSubName(eventName),
                                             durable: true,
                                             exclusive: false,
                                             autoDelete: false,
                                             arguments: null);

                consumerChannel.BasicPublish(exchange: eventBusConfig.DefaultTopicName,
                                             routingKey: eventName,
                                             mandatory: true,
                                             basicProperties: properties,
                                             body: body);

            });
        }

        public override void Subscribe<T, THandler>()
        {
            var eventName = typeof(T).Name;
            eventName = ProcessEventName(eventName);

            if (!SubsManager.HasSubscriptionsForEvent(eventName))
            {
                if (!persistenceConnection.IsConnected)
                {
                    persistenceConnection.TryConnect();
                }
                consumerChannel.QueueDeclare(queue: GetSubName(eventName),
                                             durable: true,
                                             exclusive: false,
                                             autoDelete: false,
                                             arguments: null);
                consumerChannel.QueueBind(queue: GetSubName(eventName),
                                             exchange: eventBusConfig.DefaultTopicName,
                                             routingKey: eventName
                                           );
            }
            SubsManager.AddSubscription<T, THandler>();
            StartBasicConsume(eventName);
        }

        public override void UnSubscribe<T, THandler>()
        {
            SubsManager.RemoveSubscription<T, THandler>();
        }
        private IModel CreateConsumerChannel()
        {
            if (!persistenceConnection.IsConnected)
            {
                persistenceConnection.TryConnect();
            }
            var channel = persistenceConnection.CreateModel();
            channel.ExchangeDeclare(exchange: eventBusConfig.DefaultTopicName, type: "direct");
            return channel;
        }
        private void StartBasicConsume(string eventName)
        {
            if (consumerChannel != null)
            {
                var consumer = new EventingBasicConsumer(consumerChannel);
                consumer.Received += Consumer_Received;
                consumerChannel.BasicConsume(queue: GetSubName(eventName),
                                             autoAck: false,
                                             consumer: consumer);
            }
        }

        private async void Consumer_Received(object? sender, BasicDeliverEventArgs e)
        {
            var eventName = e.RoutingKey;
            eventName = ProcessEventName(eventName);
            var message = Encoding.UTF8.GetString(e.Body.Span);
            try
            {
                await ProcessEvent(eventName, message);
            }
            catch (Exception)
            {
            }
            consumerChannel.BasicAck(e.DeliveryTag, multiple: false);
        }
    }
}
