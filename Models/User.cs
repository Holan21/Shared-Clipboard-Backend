using System.ComponentModel.DataAnnotations;

namespace Shared_Clipboard_Backend.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [StringLength(100)]
        public string Username { get; set; } = string.Empty;
        [StringLength(255)]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? LastLogin { get; set; } = null;
        public List<Devices> Devices { get; set; } = [];
        public List<ClipboardItem> SharedClipboard { get; set; } = [];
    }
}
