using EventReminder.SharedKernel.Primitives;
using FluentValidation.Results;

namespace EventReminder.Usecase.Core.Exceptions
{
    /// <summary>
    /// Represents an exception that occurs when a validation fails.
    /// </summary>
    public sealed class ValidationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class.
        /// </summary>
        /// <param name="failures">The collection of validation failures.</param>
        public ValidationException(IEnumerable<ValidationFailure> validationFailures)
            : base("One or more validation failures has occurred.")
        {
            Errors = validationFailures
                .Distinct()
                .Select(failure => new FailResponse(failure.ErrorCode, failure.ErrorMessage))
                .ToList();
        }

        /// <summary>
        /// Gets the validation errors.
        /// </summary>
        public IReadOnlyCollection<FailResponse> Errors { get; }
    }
}
