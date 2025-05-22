using Fishing_API.Data.DBContexts;
using Fishing_API.Data.Repositories.Abstracts;
using Fishing_API.Data.Repositories.Interfaces;
using Fishing_API.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace Fishing_API.Data.Repositories.Implementations {
    public class RigRepository(DatabaseContext databaseContext) : FishingInterfaceAbstract<RigsModel>, IRigRepository {
        private readonly DatabaseContext _databaseContext = databaseContext;

        public override async Task<RigsModel?> Add(RigsModel entity) {
            if (Find(entity) == null) {
                RigsModel? dbEntry = (await _databaseContext.Rigs.AddAsync(entity)).Entity;
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public override async Task<RigsModel?> Find(RigsModel entity, bool includeNestedObjects = false) {
            return await _databaseContext.Rigs
                .Where(r => r.RigName == entity.RigName)
                .FirstOrDefaultAsync();
        }

        public override IQueryable<RigsModel> ListQuery(bool includeNestedObjects = false) {
            return _databaseContext.Rigs
                .OrderBy(r => r.RigName);
        }

        public override async Task<RigsModel?> Remove(RigsModel entity) {
            RigsModel? dbEntry = await Find(entity);

            if (dbEntry != null) {
                _databaseContext.Rigs.Remove(dbEntry);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public override async Task<RigsModel?> Update(RigsModel entity, RigsModel updatedEntity) {
            RigsModel? dbEntry = await Find(entity);

            if (dbEntry != null) {
                dbEntry.RigName = updatedEntity.RigName;

                _databaseContext.Rigs.Update(dbEntry);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }
    }
}
