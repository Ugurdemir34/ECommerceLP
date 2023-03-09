using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Application.Exceptions
{
    [Serializable]
    public class ValidationException : Exception
    {
        public IEnumerable<ValidationFailure> Errors { get; private set; }

        public ValidationException(string message, IEnumerable<ValidationFailure> errors, bool appendDefaultMessage) : base(appendDefaultMessage ? $"{message} {BuildErrorMessage(errors)}" : message)
        {
            Errors = errors;
        }

        private static string BuildErrorMessage(IEnumerable<ValidationFailure> errors)
        {
            var message = $"Validation Failed : PropertyName : {errors.FirstOrDefault().PropertyName} , ErrorMessage : {errors.FirstOrDefault().ErrorMessage}";

            return message;
        }

    }
}
