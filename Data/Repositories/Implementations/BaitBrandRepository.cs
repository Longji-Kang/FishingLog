using Fishing_API.Data.DBContexts;
using Fishing_API.Data.Repositories.Interfaces;
using Fishing_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Fishing_API.Data.Repositories.Implementations {
    public class BaitBrandRepository : IFishingRepository<BaitBrandModel> {
        private readonly DatabaseContext _databaseContext;

        public BaitBrandRepository(DatabaseContext databaseContext) {
            _databaseContext = databaseContext;
        }

        public async Task<BaitBrandModel?> Add(BaitBrandModel entity) {
            if (Find(entity) == null) {
                BaitBrandModel dbEntry = (await _databaseContext.BaitBrands.AddAsync(entity)).Entity;
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public async Task<BaitBrandModel?> Remove(BaitBrandModel entity) {
            BaitBrandModel? dbEntry = await Find(entity);

            if (dbEntry != null) {
                _databaseContext.BaitBrands.Remove(dbEntry);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public async Task<BaitBrandModel?> Update(BaitBrandModel entity, BaitBrandModel updatedEntity) {
            BaitBrandModel? dbEntry = await Find(entity);

            if (dbEntry != null) {
                dbEntry.Brand = updatedEntity.Brand;

                _databaseContext.BaitBrands.Update(dbEntry);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public async Task<BaitBrandModel?> Find(BaitBrandModel entity, bool includeNestedObjects = false) {
            BaitBrandModel? baitBrand = await _databaseContext.BaitBrands
                .Where(b => b.Brand == entity.Brand)
                .FirstOrDefaultAsync();

            return baitBrand;
        }
    }
}
