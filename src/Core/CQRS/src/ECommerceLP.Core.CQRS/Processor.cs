using ECommerceLP.Core.CQRS.Abstraction;
using ECommerceLP.Core.CQRS.Abstraction.Command;
using ECommerceLP.Core.CQRS.Abstraction.Query;
using MediatR;

namespace ECommerceLP.Core.CQRS
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
            return _mediator.Send(request, cancellationToken);
        }

        public Task<T> ProcessAsync<T>(IQuery<T> request, CancellationToken cancellationToken)
        {
            return _mediator.Send(request, cancellationToken);
        }
    }
}
