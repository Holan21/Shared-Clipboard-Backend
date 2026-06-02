namespace Shared_Clipboard_Backend.Models
{
    public class SharedClipboard
    {
        public Guid Id { get; set; }
        public List<string> Data { get; set; } = [];
    }
}