using Fishing_API.Data.DBContexts;
using Fishing_API.Data.Repositories.Abstracts;
using Fishing_API.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using Fishing_API.Data.Repositories.Interfaces;

namespace Fishing_API.Data.Repositories.Implementations {
    public class BaitBrandRepository : FishingInterfaceAbstract<BaitBrandModel>, IBaitBrandRepository {
        private readonly DatabaseContext _databaseContext;

        public BaitBrandRepository(DatabaseContext databaseContext) {
            _databaseContext = databaseContext;
        }

        public override async Task<BaitBrandModel?> Add(BaitBrandModel entity) {
            if (await Find(entity) == null) {
                BaitBrandModel dbEntry = (await _databaseContext.BaitBrands.AddAsync(entity)).Entity;
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public override async Task<BaitBrandModel?> Remove(BaitBrandModel entity) {
            BaitBrandModel? dbEntry = await FindById(entity.Id);

            if (dbEntry != null) {
                _databaseContext.BaitBrands.Remove(dbEntry);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public override async Task<BaitBrandModel?> Update(BaitBrandModel updatedEntity) {
            BaitBrandModel? dbEntry = await FindById(updatedEntity.Id);

            if (dbEntry != null) {
                dbEntry.Brand = updatedEntity.Brand;

                _databaseContext.BaitBrands.Update(dbEntry);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public override async Task<BaitBrandModel?> Find(BaitBrandModel entity, bool includeNestedObjects = false) {
            BaitBrandModel? baitBrand = await _databaseContext.BaitBrands
                .Where(b => b.Brand == entity.Brand)
                .FirstOrDefaultAsync();

            return baitBrand;
        }

        public override IQueryable<BaitBrandModel> ListQuery(bool includeNestedObjects = false) {
            return _databaseContext.BaitBrands
                .OrderBy(b => b.Brand);
        }

        public override async Task<BaitBrandModel?> FindById(int id) {
            return await _databaseContext.BaitBrands
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
