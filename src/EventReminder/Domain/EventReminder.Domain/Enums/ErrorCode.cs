using System.ComponentModel;

namespace EventReminder.Domain.Enums
{
    /// <summary>
    /// ErrorCode
    /// </summary>
    public enum ErrorCode
    {
        [Description("ServerError")]
        ServerError = 0,
        [Description("NullOrEmpty")]
        NullOrEmpty = 1,
        [Description("LongerThanAllowed")]
        LongerThanAllowedLength = 2,
        [Description("InvalidFormat")]
        InvalidFormat = 3,
        [Description("TooShort")]
        TooShort = 4,
        [Description("PasswordComplexity")]
        PasswordComplexity = 5,
        [Description("UnProcessableRequest")]
        UnProcessableRequest = 6,
    }
}
