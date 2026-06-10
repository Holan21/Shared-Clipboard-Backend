using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared_Clipboard_Backend.Models.Entity;

namespace Shared_Clipboard_Backend.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id).ValueGeneratedNever();
            builder.Property(u => u.Username).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(255);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(255);
            builder.Property(u => u.CreatedAt).IsRequired().ValueGeneratedNever();
            builder.Property(u => u.LastLogin).IsRequired(false);

            builder.HasIndex(u => u.Username);
            builder.HasIndex(u => u.Email).IsUnique();


            builder.HasMany<ClipboardItem>("Clipboard")
                   .WithOne()
                   .HasForeignKey("UserId")
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
