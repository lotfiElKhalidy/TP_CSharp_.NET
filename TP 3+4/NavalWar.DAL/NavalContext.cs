using Microsoft.EntityFrameworkCore;
using NavalWar.DAL.Models;

namespace NavalWar.DAL
{
    public class NavalContext : DbContext
    {
        public NavalContext(DbContextOptions<NavalContext> options) : base(options)
        {
        }

        public DbSet<Player> players { get; set; }
        public DbSet<Session> sessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .ToTable("Player")
                .HasMany(p => p.Sessions);

            modelBuilder.Entity<Session>()
                .ToTable("Session");
        }
    }

}