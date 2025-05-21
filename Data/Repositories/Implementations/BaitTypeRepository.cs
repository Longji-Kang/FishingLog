using Fishing_API.Data.DBContexts;
using Fishing_API.Data.Repositories.Abstracts;
using Fishing_API.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace Fishing_API.Data.Repositories.Implementations {
    public class BaitTypeRepository : FishingInterfaceAbstract<BaitTypeModel> {

        private readonly DatabaseContext _databaseContext;

        public BaitTypeRepository(DatabaseContext databaseContext) {
            _databaseContext = databaseContext;
        }

        public override async Task<BaitTypeModel?> Add(BaitTypeModel entity) {
            if (Find(entity) == null) {
                BaitTypeModel dbEntry = (await _databaseContext.BaitTypes.AddAsync(entity)).Entity;
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public override async Task<BaitTypeModel?> Find(BaitTypeModel entity, bool includeNestedObjects = false) {
            BaitTypeModel? dbEntry = await _databaseContext.BaitTypes
                .Where(bt => bt.Type == entity.Type)
                .FirstOrDefaultAsync();

            return dbEntry;
        }

        public override async Task<BaitTypeModel?> Remove(BaitTypeModel entity) {
            BaitTypeModel? dbEntry = await Find(entity);

            if (dbEntry != null) {
                _databaseContext.BaitTypes.Remove(entity);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public override async Task<BaitTypeModel?> Update(BaitTypeModel entity, BaitTypeModel updatedEntity) {
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

        public override Task<IQueryable<BaitTypeModel>> ListQuery(bool includeNestedObjects = false) {
            return (Task<IQueryable<BaitTypeModel>>)_databaseContext.BaitTypes
                .OrderBy(bt => bt.Type);
        }
    }
}
