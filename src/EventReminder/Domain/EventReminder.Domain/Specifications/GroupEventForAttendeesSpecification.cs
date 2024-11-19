using EventReminder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EventReminder.Domain.Specifications
{
    /// <summary>
    /// Represents the specification for determining the group event the attendees will be attending.
    /// </summary>
    public sealed class GroupEventForAttendeesSpecification : Specification<Event>
    {
        private readonly long[] _groupEventIds;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupEventForAttendeesSpecification"/> class.
        /// </summary>
        /// <param name="attendees">The attendees.</param>
        public GroupEventForAttendeesSpecification(IReadOnlyCollection<Attendee> attendees) =>
            _groupEventIds = attendees.Select(attendee => attendee.EventId).Distinct().ToArray();

        /// <inheritdoc />
        public override Expression<Func<Event, bool>> ToExpression() => groupEvent => _groupEventIds.Contains(groupEvent.Id);
    }
}
