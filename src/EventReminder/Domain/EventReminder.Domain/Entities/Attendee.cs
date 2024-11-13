using EventReminder.Domain.Abstraction;
using EventReminder.SharedKernel.Utility;

namespace EventReminder.Domain.Entities
{
    /// <summary>
    /// Represents Attendee
    /// </summary>
    public sealed class Attendee : BaseEntity<long>, IAuditableEntity, ISoftDeletableEntity
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Attendee"/> class.
        /// </summary>
        /// <param name="invitation">The invitation.</param>
        public Attendee(Invitation invitation)
            : base()
        {
            Ensure.NotNull(invitation, "The invitation is required.", nameof(invitation));
            
            EventId = invitation.EventId;
            UserId = invitation.UserId;
        }
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
