using Fishing_API.Data.DBContexts;
using Fishing_API.Data.Repositories.Interfaces;
using Fishing_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Fishing_API.Data.Repositories.Implementations {
    public class FishSpeciesRepository(DatabaseContext databaseContext) : IFishingRepository<FishSpeciesModel> {
        private readonly DatabaseContext _databaseContext = databaseContext;

        public async Task<FishSpeciesModel?> Add(FishSpeciesModel entity) {
            if (Find(entity) == null) {
                FishSpeciesModel dbEntry = (await _databaseContext.FishSpecies.AddAsync(entity)).Entity;
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public async Task<FishSpeciesModel?> Find(FishSpeciesModel entity, bool includeNestedObjects = false) {
            return await _databaseContext.FishSpecies
                .Where(f => f.FishSpecie == entity.FishSpecie)
                .FirstOrDefaultAsync();
        }

        public async Task<FishSpeciesModel[]> List(FishSpeciesModel? lastEntity = null, bool includeNestedObjects = false, int pageSize = 10) {
            IQueryable<FishSpeciesModel> fish;

            if (lastEntity == null) {
                fish = _databaseContext.FishSpecies
                    .OrderBy(f => f.FishSpecie)
                    .ThenBy(f => f.Id)
                    .Take(pageSize);
            } else {
                fish = _databaseContext.FishSpecies
                    .Where(f => f.Id > lastEntity.Id)
                    .OrderBy(f => f.FishSpecie)
                    .ThenBy(f => f.Id)
                    .Take(pageSize);
            }

            return await fish.ToArrayAsync();
        }

        public async Task<FishSpeciesModel?> Remove(FishSpeciesModel entity) {
            FishSpeciesModel? dbEntry = await Find(entity);

            if (dbEntry != null) {
                _databaseContext.FishSpecies.Remove(dbEntry);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public async Task<FishSpeciesModel?> Update(FishSpeciesModel entity, FishSpeciesModel updatedEntity) {
            FishSpeciesModel? dbEntry = await Find(entity);

            if (dbEntry != null) {
                dbEntry.FishSpecie = updatedEntity.FishSpecie;

                _databaseContext.FishSpecies.Update(dbEntry);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }
    }
}
