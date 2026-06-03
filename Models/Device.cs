using Shared_Clipboard_Backend.Models.Dto;

namespace Shared_Clipboard_Backend.Models
{
    public class Device
    {
        public required string Name { get; set; } = string.Empty;
        public required string OSName { get; set; } = string.Empty;
        public required User User { get; set; }
    }
}
