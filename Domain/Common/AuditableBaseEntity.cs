namespace Domain.Common
{
    public abstract class AuditableBaseEntity
    {
        public Guid Id { get; private init; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public bool IsDeleted { get; set; } = default;//probably to put it here
        public DateTime LastModified { get; set; }
        public string? ModifiedBy { get; set; }
        public void UpdateLastModified(DateTime lastModified)
        {
            LastModified = lastModified;
        }
        public void UpdateLastModifiedBy(string lastModifiedBy)
        {
            ModifiedBy = lastModifiedBy;
        }
    }
}
