using System.ComponentModel.DataAnnotations;

namespace Shared_Clipboard_Backend.Models.Entity
{
    public class ClipboardItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Data { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}