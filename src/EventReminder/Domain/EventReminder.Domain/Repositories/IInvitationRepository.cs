using EventReminder.Domain.Entities;
using EventReminder.SharedKernel.Primitives;

namespace EventReminder.Domain.Repositories
{
    public interface IInvitationRepository
    {
        /// <summary>
        /// Gets the invitation with the specified identifier.
        /// </summary>
        /// <param name="invitationId">The invitation identifier.</param>
        /// <returns>The maybe instance that may contain the invitation with the specified identifier.</returns>
        Task<Result<Invitation>> GetByIdAsync(Guid invitationId);

        /// <summary>
        /// Inserts the specified invitation to the database.
        /// </summary>
        /// <param name="invitation">The invitation to be inserted to the database.</param>
        void Insert(Invitation invitation);
    }
}