using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReminder.Domain.Models
{
    /// <summary>
    /// Represents the invitation response.
    /// </summary>
    public sealed class InvitationResponse
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the friend name.
        /// </summary>
        public string FriendName { get; set; }

        /// <summary>
        /// Gets or sets the event name.
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// Gets or sets the event date and time in UTC format.
        /// </summary>
        public DateTime EventDateTimeUtc { get; set; }

        /// <summary>
        /// Gets or sets the created on date and time in UTC format.
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
    }
}
