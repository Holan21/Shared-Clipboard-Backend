using Microsoft.EntityFrameworkCore;
using Shared_Clipboard_Backend.Models;

namespace Shared_Clipboard_Backend.Data
{
    public class SharedClipboardMySQLDbContex : DbContext
    {
        private readonly IConfiguration _configuration;
        public SharedClipboardMySQLDbContex(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL(_configuration.GetConnectionString("MySQL"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Devices> Devices { get; set; }
    }
}
