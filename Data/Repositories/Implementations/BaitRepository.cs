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
                _databaseContext.Baits.Remove(dbEntry);
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

        public Task<BaitModel[]> List(BaitModel? lastEntity = null, bool includeNestedObjects = false, int pageSize = 10) {
            throw new NotImplementedException();
        }

        public Task<BaitModel[]> ListBaitsByBrand(int brandId, BaitModel? lastEntity = null, bool includeNestedObjects = false, int pageSize = 10) {
            throw new NotImplementedException();
        }

        public Task<BaitModel[]> ListBaitsByDescription(string description, BaitModel? lastEntity = null, bool includeNestedObjects = false, int pageSize = 10) {
            throw new NotImplementedException();
        }

        public Task<BaitModel[]> ListBaitsByType(int typeId, BaitModel? lastEntity = null, bool includeNestedObjects = false, int pageSize = 10) {
            throw new NotImplementedException();
        }
    }
}
