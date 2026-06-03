using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Shared_Clipboard_Backend.Models
{
    public class Devices
    {
        public uint Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string OSName { get; set; } = string.Empty;
        public User User { get; set; }
    }
}
