using EventReminder.Domain.Entities;
using EventReminder.Domain.Repositories;
using EventReminder.Domain.Specifications;
using EventReminder.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace EventReminder.Infrastructure.Persistence.Repositories
{
    internal sealed class AttendeeRepository : BaseRepository<Attendee>, IAttendeeRepository
    {
        public AttendeeRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        /// <inheritdoc />
        public async Task<IReadOnlyCollection<Attendee>> GetUnprocessedAsync(int take) =>
            await DbContext.Set<Attendee>()
                .Where(new UnprocessedAttendeeSpecification())
                .OrderBy(attendee => attendee.CreatedOnUtc)
                .Take(take)
                .ToArrayAsync();
    }
}
