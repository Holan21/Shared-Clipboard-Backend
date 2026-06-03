`using Microsoft.EntityFrameworkCore;
using Shared_Clipboard_Backend.Configuration;
using Shared_Clipboard_Backend.Models;
using Shared_Clipboard_Backend.Models.Entity;

namespace Shared_Clipboard_Backend.Data
{
    public class MySQLDbContext(IConfiguration configuration) : DbContext
    {
        private readonly IConfiguration _configuration = configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL(_configuration.GetConnectionString("MySQL"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
    }
}
