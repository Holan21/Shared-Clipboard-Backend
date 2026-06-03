using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared_Clipboard_Backend.Models.Dto
{
    public class ClipboardItemEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        [Required]
        public string Data { get; set; } = string.Empty;
        [ForeignKey(nameof(UserId))]

        public UserEntity? User { get; set; }

    }
}
