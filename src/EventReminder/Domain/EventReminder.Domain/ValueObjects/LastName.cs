using EventReminder.Domain.Exceptions;
using EventReminder.SharedKernel.Primitives;
using EventReminder.SharedKernel.Extensions;

namespace EventReminder.Domain.ValueObjects
{
    public class LastName : ValueObject
    {
        /// <summary>
        /// The name maximum length.
        /// </summary>
        public const int MaxLength = 128;

        /// <summary>
        /// Initializes a new instance of the <see cref="LastName"/> class.
        /// </summary>
        /// <param name="value">The name value.</param>
        private LastName(string value) => Value = value;

        /// <summary>
        /// Gets the name value.
        /// </summary>
        public string Value { get; }

        public static implicit operator string(LastName name) => name.Value;
        /// <summary>
        /// Creates a new <see cref="LastName"/> instance based on the specified value.
        /// </summary>
        /// <param name="lastName">The name value.</param>
        /// <returns>The result of the name creation process containing the name or an error.</returns>
        public static Response<LastName> Create(string lastName) =>
            Response.Create(lastName, DomainErrors.LastName.NullOrEmpty)
                .Ensure(n => !string.IsNullOrWhiteSpace(n), DomainErrors.LastName.NullOrEmpty)
                .Ensure(n => n.Length <= MaxLength, DomainErrors.LastName.LongerThanAllowed)
                .Map(f => new LastName(f));
        /// <inheritdoc />
        public override string ToString() => Value;

        /// <inheritdoc />
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
