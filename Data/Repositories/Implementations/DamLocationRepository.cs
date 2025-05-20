using Fishing_API.Data.DBContexts;
using Fishing_API.Data.Repositories.Interfaces;
using Fishing_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Fishing_API.Data.Repositories.Implementations {
    public class DamLocationRepository(DatabaseContext databaseContext) : IDamLocationRepository {
        private readonly DatabaseContext _databaseContext = databaseContext;

        public async Task<DamLocationModel?> Add(DamLocationModel entity) {
            if (Find(entity) == null) {
                DamLocationModel dbEntry = (await _databaseContext.AddAsync(entity)).Entity;
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public async Task<DamLocationModel?> Find(DamLocationModel entity, bool includeNestedObjects = false) {
            return await _databaseContext.DamLocations
                .Where(dl => 
                    dl.DamId == entity.DamId
                    && dl.Location == entity.Location
                )
                .FirstOrDefaultAsync();
        }

        public async Task<DamLocationModel[]> List(DamLocationModel? lastEntity = null, bool includeNestedObjects = false, int pageSize = 10) {
            IQueryable<DamLocationModel> damLocations;

            if (lastEntity == null) {
                damLocations = _databaseContext.DamLocations
                    .OrderBy(dl => dl.DamId)
                    .ThenBy(dl => dl.Location)
                    .Take(pageSize);
            } else {
                damLocations = _databaseContext.DamLocations
                    .Where(dl => dl.Id > lastEntity.Id)
                    .OrderBy(dl => dl.DamId)
                    .ThenBy(dl => dl.Location)
                    .Take(pageSize);
            }

            if (includeNestedObjects) {
                damLocations.Include(dl => dl.Dam);
            }

            return await damLocations.ToArrayAsync();
        }

        public async Task<DamLocationModel[]> ListByDam(int damId, DamLocationModel? lastEntity = null, bool includeNestedObjects = false, int pageSize = 10) {
            IQueryable<DamLocationModel> damLocations;

            if (lastEntity == null) {
                damLocations = _databaseContext.DamLocations
                    .Where(dl => dl.DamId == damId)
                    .OrderBy(dl => dl.DamId)
                    .ThenBy(dl => dl.Location)
                    .Take(pageSize);
            } else {
                damLocations = _databaseContext.DamLocations
                    .Where(dl => dl.Id > lastEntity.Id && dl.DamId == damId)
                    .OrderBy(dl => dl.DamId)
                    .ThenBy(dl => dl.Location)
                    .Take(pageSize);
            }

            if (includeNestedObjects) {
                damLocations.Include(dl => dl.Dam);
            }

            return await damLocations.ToArrayAsync();
        }

        public async Task<DamLocationModel?> Remove(DamLocationModel entity) {
            DamLocationModel? dbEntry = await Find(entity);

            if (dbEntry != null) {
                _databaseContext.Remove(dbEntry);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public async Task<DamLocationModel?> Update(DamLocationModel entity, DamLocationModel updatedEntity) {
            DamLocationModel? dbEntry = await Find(entity);

            if (dbEntry != null) {
                dbEntry.DamId = entity.DamId;
                dbEntry.Dam = entity.Dam;
                dbEntry.Location = updatedEntity.Location;

                _databaseContext.Update(dbEntry);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }
    }
}
