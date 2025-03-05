using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class EventReportConfiguration : IEntityTypeConfiguration<EventReport>
    {
        public void Configure(EntityTypeBuilder<EventReport> builder)
        {
            builder.ToTable("EventReports").HasKey(x => x.Id);

            //builder.Property(x => x.EventId).IsRequired();
            //builder.Property(x => x.EventStatusId).IsRequired();

            builder.Property(x => x.TotalNo).IsRequired();

            builder.HasIndex(x => new { x.EventId, x.EventStatusId }).IsUnique();
        }
    }
}
