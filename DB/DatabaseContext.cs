using Fishing_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Fishing_API.DB {
    public class DatabaseContext : DbContext {
        public DbSet<BaitTypeModel> BaitTypes { get; set; }
        public DbSet<BaitBrandModel> BaitBrands { get; set; }
        public DbSet<RigsModel> Rigs { get; set; }
        public DbSet<FishSpeciesModel> FishSpecies { get; set; }
        public DbSet<ProvinceModel> Provinces { get; set; }
        public DbSet<DamModel> Dam { get; set; }
        public DbSet<DamLocationModel> DamLocations { get; set; }
        public DbSet<BaitModel> BaitModels { get; set; }
        public DbSet<WeatherModel> Weather { get; set; }
        public DbSet<LogModel> LogModels { get; set; }
        public DbSet<BaitLogRelationModel> BaitLogRelations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            
        }
    }
}
