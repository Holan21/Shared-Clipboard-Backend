using Shared_Clipboard_Backend.Models.Entity;

namespace Shared_Clipboard_Backend.Services
{
    public interface ICLipboardRepositories
    {
        Task<List<ClipboardItem>> GetByIdAsync(Guid userId);
        Task AddClipboardItemAsync(Guid userId, ClipboardItem item);
        Task DeleteClipboardItemAsync(Guid userId, string data);
    }
}