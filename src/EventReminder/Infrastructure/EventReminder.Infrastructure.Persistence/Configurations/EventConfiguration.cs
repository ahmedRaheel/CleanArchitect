using EventReminder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventReminder.Infrastructure.Persistence.Configurations
{
    /// <summary>
    /// Represents Event Configuration
    /// </summary>
    internal sealed class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(@event => @event.Id);
            builder.Property(@event => @event.DateTimeUtc).IsRequired();
            builder.Property(@event => @event.Cancelled).HasDefaultValue(false);
            builder.Property(@event => @event.CreatedOnUtc).IsRequired();
            builder.Property(@event => @event.ModifiedOnUtc);
            builder.Property(@event => @event.DeletedOnUtc);
            builder.Property(@event => @event.Deleted).HasDefaultValue(false);
            builder.HasQueryFilter(@event => !@event.Deleted);
        }
    }
}
