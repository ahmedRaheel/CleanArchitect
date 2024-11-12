using EventReminder.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReminder.Domain.Entities
{
    public sealed class Invitation : BaseEntity<long>,  IAuditableEntity, ISoftDeletableEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Invitation"/> class.
        /// </summary>
        /// <remarks>
        /// Required by EF Core.
        /// </remarks>
        private Invitation()
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
        /// Gets the value indicating whether or not the invitation has been accepted.
        /// </summary>
        public bool Accepted { get; private set; }

        /// <summary>
        /// Gets the value indicating whether or not the invitation has been rejected.
        /// </summary>
        public bool Rejected { get; private set; }

        /// <summary>
        /// Gets the date and time the invitation was completed on in UTC format.
        /// </summary>
        public DateTime? CompletedOnUtc { get; private set; }

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
