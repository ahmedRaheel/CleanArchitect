using EventReminder.Domain.Exceptions;
using EventReminder.SharedKernel.Primitives;
using EventReminder.SharedKernel.Extensions;
using System.Text.RegularExpressions;

namespace EventReminder.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        /// <summary>
        /// The email maximum length.
        /// </summary>
        public const int MaxLength = 256;

        private const string EmailRegexPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

        private static readonly Lazy<Regex> EmailFormatRegex =
            new Lazy<Regex>(() => new Regex(EmailRegexPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase));

        /// <summary>
        /// Initializes a new instance of the <see cref="Email"/> class.
        /// </summary>
        /// <param name="value">The name value.</param>
        private Email(string value) => Value = value;

        /// <summary>
        /// Gets the name value.
        /// </summary>
        public string Value { get; }

        public static implicit operator string(Email name) => name.Value;
        /// <summary>
        /// Creates a new <see cref="Email"/> instance based on the specified value.
        /// </summary>
        /// <param name="Email">The name value.</param>
        /// <returns>The result of the name creation process containing the name or an error.</returns>
        public static Response<Email> Create(string email) =>
            Response.Create(email, DomainErrors.Email.NullOrEmpty)
                .Ensure(n => !string.IsNullOrWhiteSpace(n), DomainErrors.Email.NullOrEmpty)
                .Ensure(e => EmailFormatRegex.Value.IsMatch(e), DomainErrors.Email.InvalidFormat)
                .Map(f => new Email(f));
        /// <inheritdoc />
        public override string ToString() => Value;

        /// <inheritdoc />
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
