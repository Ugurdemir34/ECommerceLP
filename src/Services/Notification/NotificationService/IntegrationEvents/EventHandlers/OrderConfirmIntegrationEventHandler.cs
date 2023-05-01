using EventBus.Base.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationService.IntegrationEvents.Events;
using ECommerceLP.Application.Services;
using ECommerceLP.Common.Mail.Models;

namespace NotificationService.IntegrationEvents.EventHandlers
{
    public class OrderConfirmIntegrationEventHandler : IIntegrationEventHandler<OrderConfirmIntegrationEvent>
    {
        private readonly IMailService _mailService;

        public OrderConfirmIntegrationEventHandler(IMailService mailService)
        {
            _mailService = mailService;
        }

        public Task Handle(OrderConfirmIntegrationEvent @event)
        {
            Console.WriteLine($"{@event.Message}");
            //_mailService.SendMailAsync(message);
            return Task.CompletedTask;
        }
    }
}
