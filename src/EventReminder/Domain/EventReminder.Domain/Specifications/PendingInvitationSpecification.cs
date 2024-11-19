using EventReminder.Domain.Entities;
using System.Linq.Expressions;

namespace EventReminder.Domain.Specifications
{
    /// <summary>
    /// Represents Specification for Invitation
    /// </summary>
    public sealed class PendingInvitationSpecification : Specification<Invitation>
    {
        private readonly long _groupEventId;
        private readonly long _userId;

        public PendingInvitationSpecification(long eventId, long userId) 
        {
            _groupEventId = eventId;
            _userId = userId;
        }
        public override Expression<Func<Invitation, bool>> ToExpression() =>
            invitation => invitation.CompletedOnUtc == null &&
                          invitation.EventId == _groupEventId &&
                          invitation.UserId == _userId;
    }
}
