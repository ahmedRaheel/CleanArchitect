using EventReminder.Domain.Abstraction;
using EventReminder.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EventReminder.Domain.Entities
{
    public class Event : BaseEntity<long>, IAuditableEntity, ISoftDeletableEntity
    {        
        /// <summary>
        /// Initializes a new instance of the <see cref="Event"/> class.
        /// </summary>
        /// <remarks>
        /// Required by EF Core.
        /// </remarks>
        protected Event()
        {
        }

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        public long UserId { get; private set; }

        /// <summary>
        /// Gets the event name.
        /// </summary>
        public Name Name { get; private set; }

        /// <summary>
        /// Gets the category.
        /// </summary>
        public EventCategory Category { get; private set; }

        /// <summary>
        /// Gets the date and time of the event in UTC format.
        /// </summary>
        public DateTime DateTimeUtc { get; private set; }

        /// <summary>
        /// Gets the value indicating whether or not the event has been cancelled.
        /// </summary>
        public bool Cancelled { get; private set; }

        /// <summary>
        /// Gets the event type.
        /// </summary>
        public EventType EventType { get; private set; }

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
