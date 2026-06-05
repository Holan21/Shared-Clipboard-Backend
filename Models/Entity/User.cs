using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Shared_Clipboard_Backend.Models.Entity
{
    public class User
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
        [Required,NotNull]
        public List<Device> Devices { get; set; } = new ();
        [Required,NotNull]
        public List<ClipboardItem> Clipboard { get; set; } = new ();
    }
}
