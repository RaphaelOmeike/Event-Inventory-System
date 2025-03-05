using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Persistence.Configurations
{
    public class EventAttendeeConfiguration : IEntityTypeConfiguration<EventAttendee>
    {
        public void Configure(EntityTypeBuilder<EventAttendee> builder)
        {
            builder.ToTable("EventAttendees").HasKey(x => x.Id);

            builder.Property(x => x.Arrival).IsRequired(false);
            builder.Property(x => x.HasArrived).IsRequired();
            builder.Property(x => x.IsVerified).IsRequired();
            //
            builder.HasOne(x => x.Event)
                .WithMany(x => x.EventAttendees)
                .HasForeignKey(x => x.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Attendee)
                .WithMany(x => x.EventAttendees)
                .HasForeignKey(x => x.AttendeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.EventStatus)
                .WithMany(x => x.EventAttendees)
                .HasForeignKey(x => x.CurrentStatusId)
                .IsRequired();

            builder.HasIndex(x => new { x.EventId, x.AttendeeId }).IsUnique();
        }
    }
}
