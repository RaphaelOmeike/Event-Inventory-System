using Domain.Common;

namespace Domain.Entities
{
    public class Role : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<User> Users { get; } = [];
    }
}
