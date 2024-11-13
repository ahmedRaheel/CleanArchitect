using EventReminder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventReminder.Infrastructure.Persistence.Configurations
{
    /// <summary>
    /// Represents configuration for Attendee
    /// </summary>
    internal sealed class AttendeeConfiguration : IEntityTypeConfiguration<Attendee>
    {
        public void Configure(EntityTypeBuilder<Attendee> builder)
        {
            builder.Property(attendee => attendee.Processed).IsRequired();
            builder.Property(attendee => attendee.CreatedOnUtc).IsRequired();

            builder.Property(attendee => attendee.ModifiedOnUtc);
            builder.Property(attendee => attendee.DeletedOnUtc);
            builder.Property(attendee => attendee.Deleted).HasDefaultValue(false);

            builder.HasQueryFilter(attendee => !attendee.Deleted);
            builder.HasKey(attendee => attendee.Id);

            builder.HasOne<Event>()
                .WithMany()
                .HasForeignKey(attendee => attendee.EventId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
