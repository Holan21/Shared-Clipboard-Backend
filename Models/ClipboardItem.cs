namespace Shared_Clipboard_Backend.Models
{
    public class ClipboardItem
    {
        public string Data { get; set; } = string.Empty;
        public required User User { get; set; }

    }
}
