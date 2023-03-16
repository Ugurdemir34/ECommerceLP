using ECommerceLP.Application.CQRS.Abstract;
using ECommerceLP.Application.Messaging.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Application.CQRS.Concrete
{
    public class Processor : IProcessor
    {
        private readonly IMediator _mediator;

        public Processor(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<T> ProcessAsync<T>(ICommand<T> request, CancellationToken cancellationToken)
        {
            return _mediator.Send(request,cancellationToken);
        }

        public Task<T> ProcessAsync<T>(IQuery<T> request, CancellationToken cancellationToken)
        {
            return _mediator.Send(request,cancellationToken);
        }
    }
}
