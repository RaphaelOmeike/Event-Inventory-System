namespace Domain.Common
{
    public abstract class AuditableBaseEntity
    {
        public Guid Id { get; private init; } = Guid.NewGuid();
        public DateTimeOffset CreatedAt => DateTimeOffset.UtcNow;
        public string? CreatedBy { get; set; }
        public bool IsDeleted { get; set; } = default;//probably to put it here
        public DateTimeOffset LastModified { get; private set; } = DateTimeOffset.UtcNow;
        public string? ModifiedBy { get; set; }
        public void UpdateLastModified()
        {
            LastModified = DateTimeOffset.UtcNow;
        }
        public void UpdateLastModifiedBy(string lastModifiedBy)
        {
            ModifiedBy = lastModifiedBy;
        }
    }
}
