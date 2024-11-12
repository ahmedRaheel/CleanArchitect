using EventReminder.Domain.Abstraction;
using EventReminder.Domain.Enums;
using EventReminder.Domain.ValueObjects;

namespace EventReminder.Domain.Entities
{
    public sealed class Event : BaseEntity<long>, IAuditableEntity, ISoftDeletableEntity
    {        
        /// <summary>
        /// Initializes a new instance of the <see cref="Event"/> class.
        /// </summary>
        /// <remarks>
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
