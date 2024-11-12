using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReminder.Domain.Constants
{
    public static class DomainConstants  
    {
        public static string NameRequired = "The name is required.";
        public static string NameMaxLength = "The name is longer than allowed.";

        public static string FirstNameRequired = "The first name is required.";
        public static string FirstNameMaxLength = "The first name is longer than allowed.";

        public static string LastRequired = "The last name is required.";
        public static string LastMaxLength = "The last name is longer than allowed.";

        public static string EmailRequired = "The email is required.";
        public static string EmailInvalidFormat = "The email format is invalid.";
    }
}
