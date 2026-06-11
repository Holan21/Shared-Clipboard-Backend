using Microsoft.EntityFrameworkCore;
using Shared_Clipboard_Backend.Data;
using Shared_Clipboard_Backend.Models.Entity;
using Shared_Clipboard_Backend.Services;

namespace Shared_Clipboard_Backend.Repositories
{
    public class ClipboardRepositories : ICLipboardRepositories
    {
        private readonly MySQLDbContext _dbContext;

        public ClipboardRepositories(MySQLDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ClipboardItem>> GetByIdAsync(Guid userId)
        {
            return await _dbContext.ClipboardItems
                .AsNoTracking()
                .Where(c => c.UserId == userId)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
        }

        public async Task AddClipboardItemAsync(Guid userId, ClipboardItem item)
        {
            item.UserId = userId;
            if (item.Id == Guid.Empty)
                item.Id = Guid.NewGuid();
            if (item.CreatedAt == default)
                item.CreatedAt = DateTime.UtcNow;

            await _dbContext.ClipboardItems.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteClipboardItemAsync(Guid userId, string data)
        {
            var item = await _dbContext.ClipboardItems
                .FirstOrDefaultAsync(c => c.UserId == userId && c.Data == data);
            if (item != null)
            {
                _dbContext.ClipboardItems.Remove(item);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}