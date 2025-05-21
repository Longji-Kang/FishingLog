using Fishing_API.Data.DBContexts;
using Fishing_API.Data.Repositories.Abstracts;
using Fishing_API.Data.Repositories.Interfaces;
using Fishing_API.Models.ApiModels;
using Fishing_API.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace Fishing_API.Data.Repositories.Implementations {
    public class BaitRepository(DatabaseContext databaseContext) : FishingInterfaceAbstract<BaitModel>, IBaitRepository {
        private readonly DatabaseContext _databaseContext = databaseContext;

        public override async Task<BaitModel?> Add(BaitModel entity) {
            if (Find(entity) == null) {
                BaitModel dbEntry = (await _databaseContext.Baits.AddAsync(entity)).Entity;
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public override async Task<BaitModel?> Remove(BaitModel entity) {
            BaitModel? dbEntry = await Find(entity);

            if (dbEntry != null) {
                _databaseContext.Baits.Remove(dbEntry);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public override async Task<BaitModel?> Update(BaitModel entity, BaitModel updatedEntity) {
            BaitModel? dbEntry = await Find(entity);

            if (dbEntry != null) {
                dbEntry.BrandId = updatedEntity.BrandId;
                dbEntry.Brand = updatedEntity.Brand;
                dbEntry.BaitTypeId = updatedEntity.BaitTypeId;
                dbEntry.BaitType = updatedEntity.BaitType;
                dbEntry.Description = updatedEntity.Description;

                _databaseContext.Baits.Update(dbEntry);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public override async Task<BaitModel?> Find(BaitModel entity, bool includeNestedObjects = false) {
            return await _databaseContext.Baits
                .Where(b => b.BrandId == entity.BrandId && b.BaitTypeId == entity.BaitTypeId && b.Description == entity.Description)
                .FirstOrDefaultAsync();
        }

        public Task<IQueryable<BaitModel>> ListBaitsByBrand(int brandId, bool includeNestedObjects = false) {
            IQueryable<BaitModel> baits = _databaseContext.Baits
                .Where(b => b.BrandId == brandId)
                .OrderBy(b => b.Description)
                .ThenBy(b => b.BaitTypeId);

            if (includeNestedObjects) {
                baits
                    .Include(b => b.BaitType);
            }

            return (Task<IQueryable<BaitModel>>)baits;
        }

        public Task<IQueryable<BaitModel>> ListBaitsByType(int typeId, bool includeNestedObjects = false) {
            IQueryable<BaitModel> baits = _databaseContext.Baits
                .Where(b => b.BaitTypeId == typeId)
                .OrderBy(b => b.BrandId)
                .ThenBy(b => b.Description);

            if (includeNestedObjects) {
                baits
                    .Include(b => b.Brand);
            }

            return (Task<IQueryable<BaitModel>>)baits;
        }

        public Task<IQueryable<BaitModel>> ListBaitsByDescription(string description, bool includeNestedObjects = false) {
            IQueryable<BaitModel> baits = _databaseContext.Baits
                .Where(b => b.Description == description)
                .OrderBy(b => b.BrandId)
                .ThenBy(b => b.BaitTypeId);

            if (includeNestedObjects) {
                baits
                    .Include(b => b.Brand)
                    .Include(b => b.BaitType);
            }

            return (Task<IQueryable<BaitModel>>)baits;
        }

        public override Task<IQueryable<BaitModel>> ListQuery(bool includeNestedObjects) {
            IQueryable<BaitModel> baits = _databaseContext.Baits
                .OrderBy(b => b.BrandId)
                .ThenBy(b => b.Description)
                .ThenBy(b => b.BaitTypeId);

            if (includeNestedObjects) {
                baits
                    .Include(b => b.Brand)
                    .Include(b => b.BaitType);
            }

            return (Task<IQueryable<BaitModel>>)baits;
        }
    }
}
