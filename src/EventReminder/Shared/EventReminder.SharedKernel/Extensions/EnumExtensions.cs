using System.ComponentModel;
using System.Reflection;

namespace EventReminder.SharedKernel.Extensions
{
    public static class EnumExtensions 
    {
        public static string Description(this Enum value)
        {
            // Get the type of the enum
            Type type = value.GetType();

            // Get the member information for the enum value
            MemberInfo[] memberInfo = type.GetMember(value.ToString());

            if (memberInfo.Length > 0)
            {
                // Get the DescriptionAttribute for the enum value
                var attribute = memberInfo[0].GetCustomAttribute<DescriptionAttribute>();
                if (attribute != null)
                {
                    return attribute.Description;
                }
            }

            // Return the enum value as a string if no description is found
            return value.ToString();
        }
    }
}
