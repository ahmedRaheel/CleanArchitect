using EventReminder.SharedKernel.Primitives;

namespace EventReminder.Domain.Exceptions
{
    public static class DomainErrors
    {
        /// <summary>
        /// Contains the name errors.
        /// </summary>
        public static class Name
        {
            public static FailResponse NullOrEmpty => new("Name.NullOrEmpty", "The name is required.");
            public static FailResponse LongerThanAllowed => new("Name.LongerThanAllowed", "The name is longer than allowed.");
        }

        /// <summary>
        /// Contains the first name errors.
        /// </summary>
        public static class FirstName
        {
            public static FailResponse NullOrEmpty => new("FirstName.NullOrEmpty", "The first name is required.");
            public static FailResponse LongerThanAllowed => new("FirstName.LongerThanAllowed", "The first name is longer than allowed.");
        }

        /// <summary>
        /// Contains the first name errors.
        /// </summary>
        public static class LastName
        {
            public static FailResponse NullOrEmpty => new("LastName.NullOrEmpty", "The last name is required.");
            public static FailResponse LongerThanAllowed => new("LastName.LongerThanAllowed", "The last name is longer than allowed.");
        }

        /// <summary>
        /// Contains the first name errors.
        /// </summary>
        public static class Email
        {
            public static FailResponse NullOrEmpty => new("Email.NullOrEmpty", "The email is required.");
            public static FailResponse InvalidFormat => new("Email.InvalidFormat", "The email format is invalid.");
        }

        /// <summary>
        /// Contains the password errors.
        /// </summary>
        public static class Password
        {
            public static FailResponse NullOrEmpty => new ("Password.NullOrEmpty", "The password is required.");

            public static FailResponse TooShort => new ("Password.TooShort", "The password is too short.");

            public static FailResponse MissingUppercaseLetter => new (
                "Password.MissingUppercaseLetter",
                "The password requires at least one uppercase letter.");

            public static FailResponse MissingLowercaseLetter => new (
                "Password.MissingLowercaseLetter",
                "The password requires at least one lowercase letter.");

            public static FailResponse MissingDigit => new (
                "Password.MissingDigit",
                "The password requires at least one digit.");

            public static FailResponse MissingNonAlphaNumeric => new (
                "Password.MissingNonAlphaNumeric",
                "The password requires at least one non-alphanumeric.");
        }

        /// <summary>
        /// Contains general errors.
        /// </summary>
        public static class General
        {
            public static FailResponse UnProcessableRequest => new (
                "General.UnProcessableRequest",
                "The server could not process the request.");

            public static FailResponse ServerError => new ("General.ServerError", "The server encountered an unrecoverable error.");
        }
    }
}
