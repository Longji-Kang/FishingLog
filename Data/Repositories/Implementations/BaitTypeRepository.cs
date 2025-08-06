using Fishing_API.Data.DBContexts;
using Fishing_API.Data.Repositories.Abstracts;
using Fishing_API.Data.Repositories.Interfaces;
using Fishing_API.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace Fishing_API.Data.Repositories.Implementations {
    public class BaitTypeRepository : FishingInterfaceAbstract<BaitTypeModel>, IBaitTypeRepository {

        private readonly DatabaseContext _databaseContext;

        public BaitTypeRepository(DatabaseContext databaseContext) {
            _databaseContext = databaseContext;
        }

        public override async Task<BaitTypeModel?> Add(BaitTypeModel entity) {
            if (await Find(entity) == null) {
                BaitTypeModel dbEntry = (await _databaseContext.BaitTypes.AddAsync(entity)).Entity;
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public override async Task<BaitTypeModel?> Find(BaitTypeModel entity, bool includeNestedObjects = false) {
            BaitTypeModel? dbEntry = await _databaseContext.BaitTypes
                .Where(bt => bt.Type!.ToLower() == entity.Type!.ToLower())
                .FirstOrDefaultAsync();

            return dbEntry;
        }

        public override async Task<BaitTypeModel?> Remove(int entityId) {
            BaitTypeModel? dbEntry = await FindById(entityId);

            if (dbEntry != null) {
                _databaseContext.BaitTypes.Remove(dbEntry);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public override async Task<BaitTypeModel?> Update(BaitTypeModel updatedEntity) {
            BaitTypeModel? dbEntry = await FindById(updatedEntity.Id);

            if (dbEntry != null) {
                dbEntry.Type = updatedEntity.Type;

                _databaseContext.BaitTypes.Update(dbEntry);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public override IQueryable<BaitTypeModel> ListQuery(bool includeNestedObjects = false) {
            return _databaseContext.BaitTypes
                .OrderBy(bt => bt.Type);
        }

        public override async Task<BaitTypeModel?> FindById(int id) {
            return await _databaseContext.BaitTypes
                .Where(bt => bt.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
