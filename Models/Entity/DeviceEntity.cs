using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared_Clipboard_Backend.Models.Dto
{
    public class DeviceEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string OSName { get; set; } = string.Empty;
        [ForeignKey(nameof(UserId))]
        public UserEntity? User { get; set; }

    }
}
