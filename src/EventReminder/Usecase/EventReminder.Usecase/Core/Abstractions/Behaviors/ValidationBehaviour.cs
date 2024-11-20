using EventReminder.SharedKernel.Primitives;
using EventReminder.Usecase.Core.Abstractions.Messaging;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace EventReminder.Usecase.Core.Abstractions.Behaviors
{
    /// <summary>
    /// Represents the validation behaviour middleware.
    /// </summary>
    /// <typeparam name="TRequest">The request type.</typeparam>
    /// <typeparam name="TResponse">The response type.</typeparam>
    internal sealed class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class, IRequest<TRequest>
        where TResponse : Response
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationBehaviour{TRequest,TResponse}"/> class.
        /// </summary>
        /// <param name="validators">The validator for the current request type.</param>
        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;
      
        /// <inheritdoc />
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (request is IQuery<TRequest>) 
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);

            List<ValidationFailure> failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Any()) 
            {
                throw new ValidationException(failures);
            }
            return await next();
        }
    }
}
