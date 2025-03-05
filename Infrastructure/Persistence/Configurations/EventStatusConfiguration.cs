using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class EventStatusConfiguration : IEntityTypeConfiguration<EventStatus>
    {
        public void Configure(EntityTypeBuilder<EventStatus> builder)
        {
            builder.ToTable("EventStatuses").HasKey(x => x.Id);
            
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired(false);
            //builder.Property(x => x.EventId).IsRequired();

            builder.HasOne<EventReport>()
                .WithOne()
                .HasForeignKey<EventReport>(x => x.EventStatusId)
                .IsRequired();

            builder.Property(x => x.CreatedAt).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedBy).IsRequired(false);

            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.LastModified).IsRequired().ValueGeneratedOnUpdate();
            builder.Property(x => x.ModifiedBy).IsRequired(false);

            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}
