using EventReminder.Domain.Exceptions;
using EventReminder.SharedKernel.Primitives;
using EventReminder.SharedKernel.Extensions;

namespace EventReminder.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        /// <summary>
        /// The name maximum length.
        /// </summary>
        public const int MaxLength = 128;

        /// <summary>
        /// Initializes a new instance of the <see cref="Name"/> class.
        /// </summary>
        /// <param name="value">The name value.</param>
        private Name(string value) => Value = value;

        /// <summary>
        /// Gets the name value.
        /// </summary>
        public string Value { get; }

        public static implicit operator string(Name name) => name.Value;
        /// <summary>
        /// Creates a new <see cref="Name"/> instance based on the specified value.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <returns>The result of the name creation process containing the name or an error.</returns>
        public static Response<Name> Create(string name) =>
            Response.Create(name, DomainErrors.Name.NullOrEmpty)
                .Ensure(n => !string.IsNullOrWhiteSpace(n), DomainErrors.Name.NullOrEmpty)
                .Ensure(n => n.Length <= MaxLength, DomainErrors.Name.LongerThanAllowed)
                .Map(f => new Name(f));
        /// <inheritdoc />
        public override string ToString() => Value;

        /// <inheritdoc />
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
