using Domain.Common;

namespace Domain.Entities
{
    public class User : AuditableBaseEntity
    {
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Salt { get; set; } = null!;
        public int? ProfilePictureId { get; set; }
        public FileOnFileSystemModel? ProfilePicture { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsApproved { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; } = null!;
    }
}
