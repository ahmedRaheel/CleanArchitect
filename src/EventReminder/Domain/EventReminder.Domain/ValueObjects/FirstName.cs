using EventReminder.Domain.Exceptions;
using EventReminder.SharedKernel.Primitives;
using EventReminder.SharedKernel.Extensions;

namespace EventReminder.Domain.ValueObjects
{
    public class FirstName : ValueObject
    {
        /// <summary>
        /// The name maximum length.
        /// </summary>
        public const int MaxLength = 128;

        /// <summary>
        /// Initializes a new instance of the <see cref="FirstName"/> class.
        /// </summary>
        /// <param name="value">The name value.</param>
        private FirstName(string value) => Value = value;

        /// <summary>
        /// Gets the name value.
        /// </summary>
        public string Value { get; }

        public static implicit operator string(FirstName name) => name.Value;
        /// <summary>
        /// Creates a new <see cref="FirstName"/> instance based on the specified value.
        /// </summary>
        /// <param name="firstName">The name value.</param>
        /// <returns>The result of the name creation process containing the name or an error.</returns>
        public static Response<FirstName> Create(string firstName) =>
            Response.Create(firstName, DomainErrors.FirstName.NullOrEmpty)
                .Ensure(n => !string.IsNullOrWhiteSpace(n), DomainErrors.FirstName.NullOrEmpty)
                .Ensure(n => n.Length <= MaxLength, DomainErrors.FirstName.LongerThanAllowed)
                .Map(f => new FirstName(f));
        /// <inheritdoc />
        public override string ToString() => Value;

        /// <inheritdoc />
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
