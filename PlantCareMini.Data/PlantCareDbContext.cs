using Microsoft.EntityFrameworkCore;
using PlantCareMini.Data.Entities;

namespace PlantCareMini.Data
{
    public class PlantCareDbContext : DbContext
    {
        public PlantCareDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Plant> Plants => Set<Plant>();
        public DbSet<PlantType> PlantTypes => Set<PlantType>();
        public DbSet<GrowingLocation> GrowingLocations => Set<GrowingLocation>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PlantType>().HasKey(t => t.PlantTypeId);
            modelBuilder.Entity<GrowingLocation>().HasKey(l => l.GrowingLocationId);
            modelBuilder.Entity<Plant>(entity =>
            {
                entity.HasKey(p => p.PlantId);
                entity.ToTable("Plants", table => table.HasCheckConstraint(
                    "CK_Plants_WateringIntervalDays", "[WateringIntervalDays] > 0"));
                entity.HasOne(p => p.PlantType).WithMany(t => t.Plants)
                    .HasForeignKey(p => p.PlantTypeId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.GrowingLocation).WithMany(l => l.Plants)
                    .HasForeignKey(p => p.GrowingLocationId).OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
