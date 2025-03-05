using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Events").HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.Begin).IsRequired();
            builder.Property(x => x.End).IsRequired();
            builder.Property(x => x.MaxAttendeeNo).IsRequired();
            builder.Property(x => x.EventType).IsRequired();//
            builder.Property(x => x.IsEventOver).IsRequired();
            builder.Property(x => x.MinimumWaitingTime).IsRequired();
            builder.Property(x => x.RegistrationCode).IsRequired(false);
            builder.Property(x => x.EventCode).IsRequired(false);
            builder.Property(x => x.AccessCode).IsRequired(false);

            builder.HasOne(x => x.DefaultEventStatus)
            .WithOne()
            .HasForeignKey<Event>(x => x.DefaultStatusId)
            .IsRequired();

            builder.HasOne(x => x.Picture)
            .WithOne()
            .HasForeignKey<Event>(x => x.PictureId)
            .IsRequired(); //same as cascade

            builder.HasMany(x => x.EventStatuses)
            .WithOne(x => x.Event)
            .HasForeignKey(x => x.EventId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.EventReports)
            .WithOne(x => x.Event)
            .HasForeignKey(x => x.EventId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.CreatedAt).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedBy).IsRequired(false);

            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.LastModified).IsRequired().ValueGeneratedOnUpdate();
            builder.Property(x => x.ModifiedBy).IsRequired(false);

            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}
