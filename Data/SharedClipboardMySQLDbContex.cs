using Microsoft.EntityFrameworkCore;
using Shared_Clipboard_Backend.Models;

namespace Shared_Clipboard_Backend.Data
{
    public class SharedClipboardMySQLDbContex : DbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Devices> Devices { get; set; }
        DbSet<SharedClipboard> SharedClipboard { get; set; }

    }
}
