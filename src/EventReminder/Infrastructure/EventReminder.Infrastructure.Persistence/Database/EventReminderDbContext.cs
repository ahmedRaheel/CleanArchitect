using EventReminder.Domain.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EventReminder.Infrastructure.Persistence.Database
{
    public class EventReminderDbContext : DbContext, IDbContext
    {
        /// <inheritdoc />
        public new DbSet<TEntity> Set<TEntity>()
            where TEntity : BaseEntity<long>
            => base.Set<TEntity>();

        /// <summary>
        /// initialized the Db Context
        /// </summary>
        /// <param name="dbContextOptions"></param>
        public EventReminderDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>     
        public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            using (var transaction = await Database.BeginTransactionAsync()) 
            {
                try
                {
                    var rows = await base.SaveChangesAsync(cancellationToken);
                    await transaction.CommitAsync();
                    return rows;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }       
        }
    }
}
