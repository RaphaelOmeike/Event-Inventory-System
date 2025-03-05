using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.ToTable("Users").HasKey(x => x.Id);

            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(20);
            builder.Property(x => x.PasswordHash).IsRequired();
            builder.Property(x => x.PasswordSalt).IsRequired();

            builder.Property(x => x.IsEmailVerified).IsRequired();
            builder.Property(x => x.IsApproved).IsRequired();

            builder.HasOne(x => x.ProfilePicture)
            .WithOne()
            .HasForeignKey<User>(x => x.ProfilePictureId)
            .IsRequired(false);

            builder.HasOne(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.CreatedAt).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedBy).IsRequired(false);

            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.LastModified).IsRequired().ValueGeneratedOnUpdate();
            builder.Property(x => x.ModifiedBy).IsRequired(false);

            builder.HasIndex(x => x.Email).IsUnique();
        }
    }
}
