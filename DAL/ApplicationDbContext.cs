using Microsoft.EntityFrameworkCore;
using Model.DAL.EFModel;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureOneToManyDbRelationships(modelBuilder);
            SeedDb(modelBuilder);
        }

        private void ConfigureOneToManyDbRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasOne(pl => pl.Position)
                .WithMany(pos => pos.Players)
                .HasForeignKey(pl => pl.PositionId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void SeedDb(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().HasData(
                new Position { Id = Guid.NewGuid(), Name = "Center", DateCreated = DateTime.UtcNow, DateUpdated = null },
                new Position { Id = Guid.NewGuid(), Name = "Power Forward", DateCreated = DateTime.UtcNow, DateUpdated = null },
                new Position { Id = Guid.NewGuid(), Name = "Small Forward", DateCreated = DateTime.UtcNow, DateUpdated = null },
                new Position { Id = Guid.NewGuid(), Name = "Shooting Guard", DateCreated = DateTime.UtcNow, DateUpdated = null },
                new Position { Id = Guid.NewGuid(), Name = "Point Guard", DateCreated = DateTime.UtcNow, DateUpdated = null }
            );
        }
    }
}


