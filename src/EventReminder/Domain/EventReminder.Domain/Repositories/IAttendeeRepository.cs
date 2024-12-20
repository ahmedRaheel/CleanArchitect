﻿using EventReminder.Domain.Entities;
using EventReminder.SharedKernel.Primitives;

namespace EventReminder.Domain.Repositories
{
    public interface IAttendeeRepository
    {
        /// <summary>
        /// Gets the attendee with the specified identifier.
        /// </summary>
        /// <param name="attendeeId">The attendee identifier.</param>
        /// <returns>The maybe instance that may contain the attendee with the specified identifier.</returns>
        Task<Result<Attendee>> GetByIdAsync(Guid attendeeId);

        /// <summary>
        /// Gets the specified number of unprocessed attendees, if they exist.
        /// </summary>
        /// <param name="take">The number of attendees to take.</param>
        /// <returns>The specified number of unprocessed attendees, if they exist.</returns>
        Task<IReadOnlyCollection<Attendee>> GetUnprocessedAsync(int take);

        /// <summary>
        /// Inserts the specified attendee to the database.
        /// </summary>
        /// <param name="attendee">The attendee to be inserted into the database.</param>
        void Insert(Attendee attendee);
    }
}
