using Fishing_API.Data.DBContexts;
using Fishing_API.Data.Repositories.Interfaces;
using Fishing_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Fishing_API.Data.Repositories.Implementations {
    public class RigRepository(DatabaseContext databaseContext) : IFishingRepository<RigsModel> {
        private readonly DatabaseContext _databaseContext = databaseContext;

        public async Task<RigsModel?> Add(RigsModel entity) {
            if (Find(entity) == null) {
                RigsModel? dbEntry = (await _databaseContext.Rigs.AddAsync(entity)).Entity;
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public async Task<RigsModel?> Find(RigsModel entity, bool includeNestedObjects = false) {
            return await _databaseContext.Rigs
                .Where(r => r.RigName == entity.RigName)
                .FirstOrDefaultAsync();
        }

        public async Task<RigsModel[]> List(RigsModel? lastEntity = null, bool includeNestedObjects = false, int pageSize = 10) {
            IQueryable<RigsModel> rigs;

            if (lastEntity == null) {
                rigs = _databaseContext.Rigs
                    .OrderBy(r => r.RigName)
                    .ThenBy(r => r.Id)
                    .Take(pageSize);
            } else {
                rigs = _databaseContext.Rigs
                    .Where(r => r.Id > lastEntity.Id)
                    .OrderBy(r => r.RigName)
                    .ThenBy(r => r.Id)
                    .Take(pageSize);
            }
            
            return await rigs.ToArrayAsync();
        }

        public Task<RigsModel?> Remove(RigsModel entity) {
            throw new NotImplementedException();
        }

        public Task<RigsModel?> Update(RigsModel entity, RigsModel updatedEntity) {
            throw new NotImplementedException();
        }
    }
}
