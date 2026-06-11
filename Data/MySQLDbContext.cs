using Microsoft.EntityFrameworkCore;
using Shared_Clipboard_Backend.Configuration;
using Shared_Clipboard_Backend.Models.Entity;

namespace Shared_Clipboard_Backend.Data
{
    public class MySQLDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public MySQLDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL(_configuration.GetConnectionString("MySQL") ??
                throw new Exception("Failed to get connection string from config"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ClipboardItem> ClipboardItems { get; set; }
    }
}