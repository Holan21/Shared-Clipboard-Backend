using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Shared_Clipboard_Backend.Models.Dto
{
    public class UserEntity
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(100),Required]
        public string Username { get; set; } = string.Empty;
        [StringLength(255), Required, NotNull]
        public string Password { get; set; } = string.Empty;
        [Required,EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? LastLogin { get; set; } = null;
        public List<DeviceEntity> Devices { get; set; } = new ();
        public List<ClipboardItemEntity> Clipboard { get; set; } = new ();
    }
}
