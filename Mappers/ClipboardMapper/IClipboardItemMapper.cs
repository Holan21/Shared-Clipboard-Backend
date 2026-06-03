using Shared_Clipboard_Backend.Models;
using Shared_Clipboard_Backend.Models.Dto;

namespace Shared_Clipboard_Backend.Mappers.ClipboardMapper
{
    public interface IClipboardItemMapper
    {
        public Task<ClipboardItem> ToDtoAsync(ClipboardItemEntity clipboardItem);
    }
}
