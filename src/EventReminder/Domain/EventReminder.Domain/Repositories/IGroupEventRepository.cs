using EventReminder.Domain.Entities;
using EventReminder.SharedKernel.Primitives;

namespace EventReminder.Domain.Repositories
{
    public interface IGroupEventRepository
    {
        /// <summary>
        /// Gets the group event with the specified identifier.
        /// </summary>
        /// <param name="groupEventId">The group event identifier.</param>
        /// <returns>The maybe instance that may contain the group event with the specified identifier.</returns>
        Task<Result<Event>> GetByIdAsync(Guid groupEventId);

        /// <summary>
        /// Gets the distinct group events for the specified attendees.
        /// </summary>
        /// <param name="attendees">The attendees to get the group events for.</param>
        /// <returns>The readonly collection of group events with the specified identifiers.</returns>
        Task<IReadOnlyCollection<Event>> GetForAttendeesAsync(IReadOnlyCollection<Attendee> attendees);

        /// <summary>
        /// Inserts the specified group event to the database.
        /// </summary>
        /// <param name="groupEvent">The group event to be inserted to the database.</param>
        void Insert(Event groupEvent);
    }
}
