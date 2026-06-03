using System.ComponentModel.DataAnnotations;

namespace Shared_Clipboard_Backend.Models.Entity
{
    public class Device
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string OS { get; set; } = string.Empty;
        [Required]
        public string AcsebilityToken { get; set; } = string.Empty;
        [Required]
        public string Engine { get; set; } = string.Empty;
        [Required]
        public string Browser { get; set; } = string.Empty;
    }
}
