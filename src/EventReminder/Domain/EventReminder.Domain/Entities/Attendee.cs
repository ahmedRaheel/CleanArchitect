using EventReminder.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EventReminder.Domain.Entities
{
    public class Attendee : BaseEntity<long>, IAuditableEntity, ISoftDeletableEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Attendee"/> class.
        /// </summary>
        /// <remarks>
        /// Required by EF Core.
        /// </remarks>
        private Attendee()
        {
        }

        /// <summary>
        /// Gets the event identifier.
        /// </summary>
        public long EventId { get; private set; }

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        public long UserId { get; private set; }

        /// <summary>
        /// Gets the value indicating whether or not the event has been processed.
        /// </summary>
        public bool Processed { get; private set; }

        /// <inheritdoc />
        public DateTime CreatedOnUtc { get; }

        /// <inheritdoc />
        public DateTime? ModifiedOnUtc { get; }

        /// <inheritdoc />
        public DateTime? DeletedOnUtc { get; }

        /// <inheritdoc />
        public bool Deleted { get; }
    }
}
