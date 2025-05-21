using Fishing_API.Data.DBContexts;
using Fishing_API.Data.Repositories.Abstracts;
using Fishing_API.Data.Repositories.Interfaces;
using Fishing_API.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace Fishing_API.Data.Repositories.Implementations {
    public class FishSpeciesRepository(DatabaseContext databaseContext) : FishingInterfaceAbstract<FishSpeciesModel> {
        private readonly DatabaseContext _databaseContext = databaseContext;

        public override async Task<FishSpeciesModel?> Add(FishSpeciesModel entity) {
            if (Find(entity) == null) {
                FishSpeciesModel dbEntry = (await _databaseContext.FishSpecies.AddAsync(entity)).Entity;
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public override async Task<FishSpeciesModel?> Find(FishSpeciesModel entity, bool includeNestedObjects = false) {
            return await _databaseContext.FishSpecies
                .Where(f => f.FishSpecie == entity.FishSpecie)
                .FirstOrDefaultAsync();
        }

        public override Task<IQueryable<FishSpeciesModel>> ListQuery(bool includeNestedObjects = false) {
            return (Task<IQueryable<FishSpeciesModel>>)_databaseContext.FishSpecies
                .OrderBy(f => f.FishSpecie);
        }

        public override async Task<FishSpeciesModel?> Remove(FishSpeciesModel entity) {
            FishSpeciesModel? dbEntry = await Find(entity);

            if (dbEntry != null) {
                _databaseContext.FishSpecies.Remove(dbEntry);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public override async Task<FishSpeciesModel?> Update(FishSpeciesModel entity, FishSpeciesModel updatedEntity) {
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
