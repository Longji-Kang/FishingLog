using Fishing_API.Models;
using Fishing_API.Seeding.Seeders;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Fishing_API.DB {
    public class DatabaseContext : DbContext {
        public DbSet<BaitTypeModel> BaitTypes { get; set; }
        public DbSet<BaitBrandModel> BaitBrands { get; set; }
        public DbSet<RigsModel> Rigs { get; set; }
        public DbSet<FishSpeciesModel> FishSpecies { get; set; }
        public DbSet<ProvinceModel> Provinces { get; set; }
        public DbSet<DamModel> Dam { get; set; }
        public DbSet<DamLocationModel> DamLocations { get; set; }
        public DbSet<BaitModel> Baits { get; set; }
        public DbSet<WeatherModel> Weather { get; set; }
        public DbSet<LogModel> LogModels { get; set; }
        public DbSet<BaitLogRelationModel> BaitLogRelations { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            string execPath = Assembly.GetExecutingAssembly().Location;
            string workingDir = Path.GetDirectoryName(execPath)!;
            /*
             ** Generate objects from JSON documents
             */
            /* Bait Brands */
            BaitBrandSeeder baitBrandSeeder = new BaitBrandSeeder();
            baitBrandSeeder.seed(modelBuilder, workingDir);

            /* Bait Types */
            BaitTypeSeeder baitTypeSeeder = new BaitTypeSeeder();
            baitTypeSeeder.seed(modelBuilder, workingDir);

            /* Baits */
            BaitSeeder baitSeeder = new BaitSeeder();
            baitSeeder.seed(modelBuilder, workingDir);

            /* Rigs */
            RigSeeder rigSeeder = new RigSeeder();
            rigSeeder.seed(modelBuilder, workingDir);

            /* Provinces */
            ProvincesSeeder provincesSeeder = new ProvincesSeeder();
            provincesSeeder.seed(modelBuilder, workingDir);

            /* Dams */
            DamSeeder damSeeder = new DamSeeder();
            damSeeder.seed(modelBuilder, workingDir);
        }
    }
}
