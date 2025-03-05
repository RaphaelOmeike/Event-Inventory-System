using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<ActionsHistory> ActionsHistories => Set<ActionsHistory>();
        public DbSet<Attendee> Attendees => Set<Attendee>();
        public DbSet<Event> Events => Set<Event>();
        public DbSet<EventAttendee> EventAttendees => Set<EventAttendee>();
        public DbSet<EventReport> EventReports => Set<EventReport>();
        public DbSet<EventStatus> EventStatuses => Set<EventStatus>();
        public DbSet<FileOnDatabaseModel> FilesOnDatabase => Set<FileOnDatabaseModel>();
        public DbSet<FileOnFileSystemModel> FilesOnFileSystem => Set<FileOnFileSystemModel>();

        public DbSet<Role> Roles => Set<Role>();
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("eventinventorysystemdb");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
