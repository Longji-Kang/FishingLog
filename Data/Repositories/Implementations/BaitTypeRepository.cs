using Fishing_API.Data.DBContexts;
using Fishing_API.Data.Repositories.Interfaces;
using Fishing_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Fishing_API.Data.Repositories.Implementations {
    public class BaitTypeRepository : IFishingRepository<BaitTypeModel> {

        private readonly DatabaseContext _databaseContext;

        public BaitTypeRepository(DatabaseContext databaseContext) {
            _databaseContext = databaseContext;
        }

        public async Task<BaitTypeModel?> Add(BaitTypeModel entity) {
            if (Find(entity) == null) {
                BaitTypeModel dbEntry = (await _databaseContext.BaitTypes.AddAsync(entity)).Entity;
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public async Task<BaitTypeModel?> Find(BaitTypeModel entity, bool includeNestedObjects = false) {
            BaitTypeModel? dbEntry = await _databaseContext.BaitTypes
                .Where(bt => bt.Type == entity.Type)
                .FirstOrDefaultAsync();

            return dbEntry;
        }

        public async Task<BaitTypeModel?> Remove(BaitTypeModel entity) {
            BaitTypeModel? dbEntry = await Find(entity);

            if (dbEntry != null) {
                _databaseContext.BaitTypes.Remove(entity);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public async Task<BaitTypeModel?> Update(BaitTypeModel entity, BaitTypeModel updatedEntity) {
            BaitTypeModel? dbEntry = await Find(entity);

            if (dbEntry != null) {
                dbEntry.Type = updatedEntity.Type;

                _databaseContext.BaitTypes.Update(dbEntry);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public async Task<BaitTypeModel[]> List(BaitTypeModel? lastEntity = null, bool includeNestedObjects = false, int pageSize = 10) {
            if (lastEntity == null) {
                return await _databaseContext.BaitTypes
                    .OrderBy(x => x.Type)
                    .Take(pageSize)
                    .ToArrayAsync();
            } else {
                return await _databaseContext.BaitTypes
                     .Where(bt => bt.Id > lastEntity.Id)
                    .OrderBy(x => x.Type)
                    .Take(pageSize)
                    .ToArrayAsync();
            }
        }
    }
}
