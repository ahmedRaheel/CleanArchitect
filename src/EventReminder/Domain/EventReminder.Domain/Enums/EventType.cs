using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReminder.Domain.Enums
{
    /// <summary>
    /// Represents the event type.
    /// </summary>
    public enum EventType
    {
        /// <summary>
        /// Personal event.
        /// </summary>
        PersonalEvent = 0,

        /// <summary>
        /// Group event.
        /// </summary>
        GroupEvent = 1
    }
}
