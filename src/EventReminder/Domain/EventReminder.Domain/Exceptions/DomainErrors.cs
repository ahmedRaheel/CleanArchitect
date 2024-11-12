using EventReminder.Domain.Constants;
using EventReminder.Domain.Enums;
using EventReminder.SharedKernel.Primitives;
using EventReminder.SharedKernel.Extensions;

namespace EventReminder.Domain.Exceptions
{
    public static class DomainErrors
    {
        /// <summary>
        /// Contains the name errors.
        /// </summary>
        public static class Name
        {
            public static FailResponse NullOrEmpty => new(ErrorCode.NullOrEmpty.Description(), DomainConstants.NameRequired);
            public static FailResponse LongerThanAllowed => new(ErrorCode.LongerThanAllowedLength.Description(), DomainConstants.NameMaxLength);
        }

        /// <summary>
        /// Contains the first name errors.
        /// </summary>
        public static class FirstName
        {
            public static FailResponse NullOrEmpty => new(ErrorCode.NullOrEmpty.Description(), "The first name is required.");
            public static FailResponse LongerThanAllowed => new(ErrorCode.LongerThanAllowedLength.Description(), "The first name is longer than allowed.");
        }

        /// <summary>
        /// Contains the first name errors.
        /// </summary>
        public static class LastName
        {
            public static FailResponse NullOrEmpty => new(ErrorCode.NullOrEmpty.Description(), "The last name is required.");
            public static FailResponse LongerThanAllowed => new(ErrorCode.LongerThanAllowedLength.Description(), "The last name is longer than allowed.");
        }

        /// <summary>
        /// Contains the first name errors.
        /// </summary>
        public static class Email
        {
            public static FailResponse NullOrEmpty => new(ErrorCode.NullOrEmpty.Description(), "The email is required.");
            public static FailResponse InvalidFormat => new(ErrorCode.InvalidFormat.Description(), "The email format is invalid.");
        }

        /// <summary>
        /// Contains the password errors.
        /// </summary>
        public static class Password
        {
            public static FailResponse NullOrEmpty => new (ErrorCode.NullOrEmpty.Description(), "The password is required.");

            public static FailResponse TooShort => new (ErrorCode.TooShort.Description(), "The password is too short.");

            public static FailResponse MissingUppercaseLetter => new (
                 ErrorCode.PasswordComplexity.Description(),
                "The password requires at least one uppercase letter.");

            public static FailResponse MissingLowercaseLetter => new (
                 ErrorCode.PasswordComplexity.Description(),
                "The password requires at least one lowercase letter.");

            public static FailResponse MissingDigit => new (
                 ErrorCode.PasswordComplexity.Description(),
                "The password requires at least one digit.");

            public static FailResponse MissingNonAlphaNumeric => new (
                 ErrorCode.PasswordComplexity.Description(),
                "The password requires at least one non-alphanumeric.");
        }

        /// <summary>
        /// Contains general errors.
        /// </summary>
        public static class General
        {
            public static FailResponse UnProcessableRequest => new (
                 ErrorCode.UnProcessableRequest.Description(),
                "The server could not process the request.");

            public static FailResponse ServerError => new(ErrorCode.ServerError.Description(), "The server encountered an unrecoverable error.");
        }
    }
}
