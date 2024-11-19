using EventReminder.Domain.Abstraction;
using EventReminder.Domain.Specifications;
using EventReminder.Infrastructure.Persistence.Database;
using EventReminder.SharedKernel.Primitives;
using Microsoft.EntityFrameworkCore;

namespace EventReminder.Infrastructure.Persistence.Repositories
{
    internal abstract class BaseRepository<TEntity> where TEntity : BaseEntity<long>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        protected BaseRepository(IDbContext dbContext) => DbContext = dbContext;

        /// <summary>
        /// Gets the database context.
        /// </summary>
        protected IDbContext DbContext { get; }

        /// <summary>
        /// Gets the entity with the specified identifier.
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        /// <returns>The maybe instance that may contain the entity with the specified identifier.</returns>
        public async Task<Result<TEntity>> GetByIdAsync(Guid id) => await DbContext.Set<TEntity>().FirstOrDefaultAsync<TEntity>(id);

        /// <summary>
        /// Inserts the specified entity into the database.
        /// </summary>
        /// <param name="entity">The entity to be inserted into the database.</param>
        public void Insert(TEntity entity) => DbContext.Set<TEntity>().Add(entity);       

        /// <summary>
        /// Updates the specified entity in the database.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        public void Update(TEntity entity) => DbContext.Set<TEntity>().Update(entity);

        /// <summary>
        /// Removes the specified entity from the database.
        /// </summary>
        /// <param name="entity">The entity to be removed from the database.</param>
        public void Remove(TEntity entity) => DbContext.Set<TEntity>().Remove(entity);

        /// <summary>
        /// Checks if any entity meets the specified specification.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns>True if any entity meets the specified specification, otherwise false.</returns>
        protected async Task<bool> AnyAsync(Specification<TEntity> specification) =>
            await DbContext.Set<TEntity>().AnyAsync(specification);

        /// <summary>
        /// Gets the first entity that meets the specified specification.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns>The maybe instance that may contain the first entity that meets the specified specification.</returns>
        protected async Task<Result<TEntity>> FirstOrDefaultAsync(Specification<TEntity> specification) =>
            await DbContext.Set<TEntity>().FirstOrDefaultAsync(specification);
    }
}
