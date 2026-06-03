using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Shared_Clipboard_Backend.Models
{
    public class ClipboardItem
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Data { get; set; } = string.Empty;


    }
}
