namespace Shared_Clipboard_Backend.Models
{
    public class ClipboardItem
    {
        public uint Id { get; set; }
        public string Data { get; set; } = string.Empty;
        public User User { get; set;}
    }
}
