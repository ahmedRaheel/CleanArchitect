using EventReminder.Domain.Entities;
using EventReminder.Domain.Repositories;
using EventReminder.Domain.Specifications;
using EventReminder.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace EventReminder.Infrastructure.Persistence.Repositories
{
    internal sealed class GroupEventRepository : BaseRepository<Event>, IGroupEventRepository
    {
        public GroupEventRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        /// <inheritdoc />
        public async Task<IReadOnlyCollection<Event>> GetForAttendeesAsync(IReadOnlyCollection<Attendee> attendees) =>
            attendees.Any()
                ? await DbContext.Set<Event>().Where(new GroupEventForAttendeesSpecification(attendees)).ToArrayAsync()
                : Array.Empty<Event>();
    }
}
