using ECommerceLP.Core.Abstraction.Exception;
using ECommerceLP.Core.CQRS.Abstraction.Command;
using FluentValidation;
using MediatR;

namespace ECommerceLP.Core.CQRS.Validation
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : class, ICommand<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }
            var context = new ValidationContext<TRequest>(request);
            var errors = _validators
                           .Select(v => v.Validate(context))
                           .SelectMany(result => result.Errors)
                           .Where(f => f != null)
                           .ToList();

            if (errors.Count != 0)
            {
                throw new CustomBusinessException("", errors, true);
            }
            return await next();

        }
    }
}
