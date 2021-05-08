using Microsoft.EntityFrameworkCore;

namespace Streamer.Database
{
    public class DatabaseContext : DbContext
    {
        private readonly Config _config;

        public DatabaseContext(Config config)
        {
            _config = config;
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<LiveVideo> LiveVideos { get; set; }
        public DbSet<SavedVideo> SavedVideos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql(_config.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
