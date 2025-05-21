using Fishing_API.Data.DBContexts;
using Fishing_API.Data.Repositories.Abstracts;
using Fishing_API.Data.Repositories.Interfaces;
using Fishing_API.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace Fishing_API.Data.Repositories.Implementations {
    public class DamLocationRepository(DatabaseContext databaseContext) : FishingInterfaceAbstract<DamLocationModel>, IDamLocationRepository {
        private readonly DatabaseContext _databaseContext = databaseContext;

        public override async Task<DamLocationModel?> Add(DamLocationModel entity) {
            if (Find(entity) == null) {
                DamLocationModel dbEntry = (await _databaseContext.AddAsync(entity)).Entity;
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public override async Task<DamLocationModel?> Find(DamLocationModel entity, bool includeNestedObjects = false) {
            return await _databaseContext.DamLocations
                .Where(dl => 
                    dl.DamId == entity.DamId
                    && dl.Location == entity.Location
                )
                .FirstOrDefaultAsync();
        }

        public IQueryable<DamLocationModel> ListByDam(int damId, bool includeNestedObjects = false) {
            IQueryable<DamLocationModel> damLocations = _databaseContext.DamLocations
                .Where(dl => dl.DamId == damId)
                .OrderBy(dl => dl.Location);

            if (includeNestedObjects) {
                damLocations.Include(dl => dl.Dam);
            }

            return damLocations;
        }

        public override IQueryable<DamLocationModel> ListQuery(bool includeNestedObjects = false) {
            IQueryable<DamLocationModel> damLocations = _databaseContext.DamLocations
                .OrderBy(dl => dl.DamId)
                .ThenBy(dl => dl.Location);

            if (includeNestedObjects) {
                damLocations.Include(dl => dl.Dam);
            }

            return damLocations;
        }

        public override async Task<DamLocationModel?> Remove(DamLocationModel entity) {
            DamLocationModel? dbEntry = await Find(entity);

            if (dbEntry != null) {
                _databaseContext.Remove(dbEntry);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public override async Task<DamLocationModel?> Update(DamLocationModel entity, DamLocationModel updatedEntity) {
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
