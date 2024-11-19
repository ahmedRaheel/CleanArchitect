using EventReminder.Domain.Entities;
using System.Linq.Expressions;

namespace EventReminder.Domain.Specifications
{
    /// <summary>
    /// Represents the specification for determining the unprocessed attendee.
    /// </summary>
    public sealed class UnprocessedAttendeeSpecification : Specification<Attendee>
    {
        /// <inheritdoc />
        public override Expression<Func<Attendee, bool>> ToExpression() => attendee => !attendee.Processed;
    }
}
