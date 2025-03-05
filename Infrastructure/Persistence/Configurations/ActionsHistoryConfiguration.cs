using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ActionsHistoryConfiguration : IEntityTypeConfiguration<ActionsHistory>
    {
        public void Configure(EntityTypeBuilder<ActionsHistory> builder)
        {
            builder.ToTable("ActionsHistory").HasKey(x => x.Id);

            builder.Property(x => x.Occured).IsRequired();
            builder.Property(x => x.PermissionGranted).IsRequired();


            builder.HasOne(x => x.EventAttendee)
            .WithMany(x => x.ActionsTaken)
            .HasForeignKey(x => x.EventAttendeeId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.EventAttendeeId).IsUnique();
        }
    }
}
