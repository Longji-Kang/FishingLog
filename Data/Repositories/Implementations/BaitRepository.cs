using Fishing_API.Data.DBContexts;
using Fishing_API.Data.Repositories.Interfaces;
using Fishing_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Fishing_API.Data.Repositories.Implementations {
    public class BaitRepository(DatabaseContext databaseContext) : IBaitRepository<BaitModel> {
        private readonly DatabaseContext _databaseContext = databaseContext;

        public async Task<BaitModel?> Add(BaitModel entity) {
            if (Find(entity) == null) {
                BaitModel dbEntry = (await _databaseContext.Baits.AddAsync(entity)).Entity;
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public async Task<BaitModel?> Remove(BaitModel entity) {
            BaitModel? dbEntry = await Find(entity);

            if (dbEntry != null) {
                _databaseContext.Baits.Remove(dbEntry);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public async Task<BaitModel?> Update(BaitModel entity, BaitModel updatedEntity) {
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

        public async Task<BaitModel?> Find(BaitModel entity, bool includeNestedObjects = false) {
            return await _databaseContext.Baits
                .Where(b => b.BrandId == entity.BrandId && b.BaitTypeId == entity.BaitTypeId && b.Description == entity.Description)
                .FirstOrDefaultAsync();
        }

        public async Task<BaitModel[]> List(BaitModel? lastEntity = null, bool includeNestedObjects = false, int pageSize = 10) {
            IQueryable<BaitModel> baits;

            if (lastEntity == null) {
                baits = _databaseContext.Baits
                    .OrderBy(b => b.Description)
                    .ThenBy(b => b.BrandId)
                    .ThenBy(b => b.BaitTypeId)
                    .ThenBy(b => b.Id)
                    .Take(pageSize);
            } else {
                baits = _databaseContext.Baits
                    .Where(b => b.Id > lastEntity.Id)
                    .OrderBy(b => b.Description)
                    .ThenBy(b => b.BrandId)
                    .ThenBy(b => b.BaitTypeId)
                    .ThenBy(b => b.Id)
                    .Take(pageSize);
            }

            if (includeNestedObjects) {
                return await baits
                    .Include(b => b.Brand)
                    .Include(b => b.BaitType)
                    .ToArrayAsync();
            } else {
                return await baits.ToArrayAsync();
            }
        }

        public async Task<BaitModel[]> ListBaitsByBrand(int brandId, BaitModel? lastEntity = null, bool includeNestedObjects = false, int pageSize = 10) {
            IQueryable<BaitModel> baits;
            
            if (lastEntity == null) {
                baits = _databaseContext.Baits
                    .Where(b => b.BrandId == brandId)
                    .OrderBy(b => b.Description)
                    .ThenBy(b => b.BaitTypeId)
                    .ThenBy(b => b.Id)
                    .Take(pageSize);
            } else {
                baits = _databaseContext.Baits
                    .Where(b => b.BrandId == brandId && b.Id > lastEntity.Id)
                    .OrderBy(b => b.Description)
                    .ThenBy(b => b.BaitTypeId)
                    .ThenBy(b => b.Id)
                    .Take(pageSize);
            }

            if (includeNestedObjects) {
                return await baits
                    .Include(b => b.Brand)
                    .Include(b => b.BaitType)
                    .ToArrayAsync();
            } else {
                return await baits.ToArrayAsync();
            }
        }

        public async Task<BaitModel[]> ListBaitsByDescription(string description, BaitModel? lastEntity = null, bool includeNestedObjects = false, int pageSize = 10) {
            IQueryable<BaitModel> baits;

            if (lastEntity == null) {
                baits = _databaseContext.Baits
                    .Where(b => b.Description == description)
                    .OrderBy(b => b.BrandId)
                    .ThenBy(b => b.BaitTypeId)
                    .ThenBy(b => b.Id)
                    .Take(pageSize);
            } else {
                baits = _databaseContext.Baits
                    .Where(b => b.Description == description && b.Id > lastEntity.Id)
                    .OrderBy(b => b.BrandId)
                    .ThenBy(b => b.BaitTypeId)
                    .ThenBy(b => b.Id)
                    .Take(pageSize);
            }

            if (includeNestedObjects) {
                return await baits
                    .Include(b => b.Brand)
                    .Include(b => b.BaitType)
                    .ToArrayAsync();
            } else {
                return await baits.ToArrayAsync();
            }
        }

        public async Task<BaitModel[]> ListBaitsByType(int typeId, BaitModel? lastEntity = null, bool includeNestedObjects = false, int pageSize = 10) {
            IQueryable<BaitModel> baits;

            if (lastEntity == null) {
                baits = _databaseContext.Baits
                    .Where(b => b.BaitTypeId == typeId)
                    .OrderBy(b => b.Description)
                    .ThenBy(b => b.BrandId)
                    .ThenBy(b => b.BaitTypeId)
                    .ThenBy(b => b.Id)
                    .Take(pageSize);
            } else {
                baits = _databaseContext.Baits
                    .Where(b => b.BaitTypeId == typeId && b.Id > lastEntity.Id)
                    .OrderBy(b => b.Description)
                    .ThenBy(b => b.BrandId)
                    .ThenBy(b => b.BaitTypeId)
                    .ThenBy(b => b.Id)
                    .Take(pageSize);
            }

            if (includeNestedObjects) {
                return await baits
                    .Include(b => b.Brand)
                    .Include(b => b.BaitType)
                    .ToArrayAsync();
            } else {
                return await baits.ToArrayAsync();
            }
        }
    }
}
