using EventReminder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReminder.Infrastructure.Persistence.Configurations
{
    /// <summary>
    /// Represents Invitation Configuration
    /// </summary>
    internal sealed class InvitationConfiguration : IEntityTypeConfiguration<Invitation>
    {
        public void Configure(EntityTypeBuilder<Invitation> builder)
        {
            builder.HasKey(invitation => invitation.Id);
            builder.Property(invitation => invitation.Accepted).HasDefaultValue(false);
            builder.Property(invitation => invitation.Rejected).HasDefaultValue(false);
            builder.Property(invitation => invitation.CompletedOnUtc);
            builder.Property(invitation => invitation.CreatedOnUtc).IsRequired();
            builder.Property(invitation => invitation.ModifiedOnUtc);
            builder.Property(invitation => invitation.DeletedOnUtc);
            builder.Property(invitation => invitation.Deleted).HasDefaultValue(false);
            builder.HasQueryFilter(invitation => !invitation.Deleted);
        }
    }
}
