using System.ComponentModel.DataAnnotations;

namespace Shared_Clipboard_Backend.Models
{
    public class User
    {
        [StringLength(100)]
        public required string Username { get; set; } = string.Empty;
        [StringLength(72)]
        public required string Password { get; set; }
        public required string Email { get; set; } = string.Empty;
        public required DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? LastLogin { get; set; } = null;

    }
}
