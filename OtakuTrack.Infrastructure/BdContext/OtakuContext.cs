using Microsoft.EntityFrameworkCore;
using OtakuTrack.Domain.Entities;
using OtakuTrack.Domain.Entities.LogError;

namespace OtakuTrack.Infrastructure.BdContext
{
    public class OtakuContext : DbContext
    {
        public OtakuContext(DbContextOptions<OtakuContext> options) : base(options) { }

        public DbSet<Anime> Animes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<Episode> Episodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre>()
                .HasMany(g => g.Animes)
                .WithOne(a => a.Genre)
                .HasForeignKey(a => a.GenreId);

            modelBuilder.Entity<Anime>()
                .HasMany(a => a.Reviews)
                .WithOne(r => r.Anime)
                .HasForeignKey(r => r.AnimeId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Reviews)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Anime>()
               .HasMany(a => a.EpisodesList) // Atualize para usar EpisodesList
               .WithOne(r => r.Anime)
               .HasForeignKey(r => r.AnimeId);
        }
    }
}
