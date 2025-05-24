using Fishing_API.Data.DBContexts;
using Fishing_API.Data.Repositories.Abstracts;
using Fishing_API.Data.Repositories.Interfaces;
using Fishing_API.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace Fishing_API.Data.Repositories.Implementations {
    public class LogAggregationRepository(DatabaseContext databaseContext) : FishingInterfaceAbstract<BaitLogRelationModel>, ILogAggregationRepository {
        private readonly DatabaseContext _databaseContext = databaseContext;

        public override async Task<BaitLogRelationModel?> Add(BaitLogRelationModel entity) {
            if (Find(entity) == null) {
                BaitLogRelationModel baitLog = (await _databaseContext.BaitLogRelations.AddAsync(entity)).Entity;
                await _databaseContext.SaveChangesAsync();

                return baitLog;
            } else {
                return null;
            }
        }

        public override async Task<BaitLogRelationModel?> Find(BaitLogRelationModel entity, bool includeNestedObjects = false) {
            return await _databaseContext.BaitLogRelations
                .Where(blr =>
                    blr.BaitId == entity.BaitId &&
                    blr.LogId == entity.LogId
                )
                .FirstOrDefaultAsync();
        }

        public IQueryable<BaitLogRelationModel> ListByBaitDescription(string baitDesc, bool includeNestedObjects) {
            IQueryable<BaitLogRelationModel> baitLogs = _databaseContext.BaitLogRelations
                .Where(blr => blr.Bait!.Description == baitDesc)
                .OrderBy(blr => blr.Bait!.BrandId)
                .ThenBy(blr => blr.Bait!.BaitTypeId)
                .ThenBy(blr => blr.Log!.DamLocation!.DamId)
                .ThenBy(blr => blr.Log!.DamLocationId)
                .ThenBy(blr => blr.Log!.FishSpecieId);

            if (includeNestedObjects) {
                baitLogs
                    .Include(blr => blr.Bait)
                    .Include(blr => blr.Bait!.BrandId)
                    .Include(blr => blr.Bait!.BaitTypeId)
                    .Include(blr => blr.Log!.FishSpecie)
                    .Include(blr => blr.Log!.Rigs)
                    .Include(blr => blr.Log!.DamLocation)
                    .Include(blr => blr.Log!.DamLocation!.Dam)
                    .Include(blr => blr.Log!.Weather);
            }

            return baitLogs;
        }

        public IQueryable<BaitLogRelationModel> ListByBaitBrand(int brandId, bool includeNestedObjects) {
            IQueryable<BaitLogRelationModel> baitLogs = _databaseContext.BaitLogRelations
                .OrderBy(blr => blr.Bait!.Description)
                .ThenBy(blr => blr.Bait!.BaitTypeId)
                .ThenBy(blr => blr.Log!.DamLocation!.DamId)
                .ThenBy(blr => blr.Log!.DamLocationId)
                .ThenBy(blr => blr.Log!.FishSpecieId);

            if (includeNestedObjects) {
                baitLogs
                    .Include(blr => blr.Bait)
                    .Include(blr => blr.Bait!.BrandId)
                    .Include(blr => blr.Bait!.BaitTypeId)
                    .Include(blr => blr.Log!.FishSpecie)
                    .Include(blr => blr.Log!.Rigs)
                    .Include(blr => blr.Log!.DamLocation)
                    .Include(blr => blr.Log!.DamLocation!.Dam)
                    .Include(blr => blr.Log!.Weather);
            }

            return baitLogs;
        }

        public IQueryable<BaitLogRelationModel> ListByBaitType(int baitTypeId, bool includeNestedObjects) {
            IQueryable<BaitLogRelationModel> baitLogs = _databaseContext.BaitLogRelations
                .Where(blr => blr.Bait!.BaitTypeId == baitTypeId)
                .OrderBy(blr => blr.Bait!.Description)
                .ThenBy(blr => blr.Bait!.BrandId)
                .ThenBy(blr => blr.Log!.DamLocation!.DamId)
                .ThenBy(blr => blr.Log!.DamLocationId)
                .ThenBy(blr => blr.Log!.FishSpecieId);

            if (includeNestedObjects) {
                baitLogs
                    .Include(blr => blr.Bait)
                    .Include(blr => blr.Bait!.BrandId)
                    .Include(blr => blr.Bait!.BaitTypeId)
                    .Include(blr => blr.Log!.FishSpecie)
                    .Include(blr => blr.Log!.Rigs)
                    .Include(blr => blr.Log!.DamLocation)
                    .Include(blr => blr.Log!.DamLocation!.Dam)
                    .Include(blr => blr.Log!.Weather);
            }

            return baitLogs;
        }

        public IQueryable<BaitLogRelationModel> ListByDam(int damId, bool includeNestedObjects) {
            IQueryable<BaitLogRelationModel> baitLogs = _databaseContext.BaitLogRelations
                .Where(blr => blr.Log!.DamLocation!.DamId == damId)
                .OrderBy(blr => blr.Bait!.Description)
                .ThenBy(blr => blr.Bait!.BrandId)
                .ThenBy(blr => blr.Bait!.BaitTypeId)
                .ThenBy(blr => blr.Log!.DamLocationId)
                .ThenBy(blr => blr.Log!.FishSpecieId);

            if (includeNestedObjects) {
                baitLogs
                    .Include(blr => blr.Bait)
                    .Include(blr => blr.Bait!.BrandId)
                    .Include(blr => blr.Bait!.BaitTypeId)
                    .Include(blr => blr.Log!.FishSpecie)
                    .Include(blr => blr.Log!.Rigs)
                    .Include(blr => blr.Log!.DamLocation)
                    .Include(blr => blr.Log!.DamLocation!.Dam)
                    .Include(blr => blr.Log!.Weather);
            }

            return baitLogs;
        }

        public IQueryable<BaitLogRelationModel> ListBySpecies(int speciesId, bool includeNestedObjects) {
            IQueryable<BaitLogRelationModel> baitLogs = _databaseContext.BaitLogRelations
                .Where(blr => blr.Log!.FishSpecieId == speciesId)
                .OrderBy(blr => blr.Bait!.Description)
                .ThenBy(blr => blr.Bait!.BrandId)
                .ThenBy(blr => blr.Bait!.BrandId)
                .ThenBy(blr => blr.Bait!.BaitTypeId)
                .ThenBy(blr => blr.Log!.DamLocation!.DamId)
                .ThenBy(blr => blr.Log!.DamLocationId);

            if (includeNestedObjects) {
                baitLogs
                    .Include(blr => blr.Bait)
                    .Include(blr => blr.Bait!.BrandId)
                    .Include(blr => blr.Bait!.BaitTypeId)
                    .Include(blr => blr.Log!.FishSpecie)
                    .Include(blr => blr.Log!.Rigs)
                    .Include(blr => blr.Log!.DamLocation)
                    .Include(blr => blr.Log!.DamLocation!.Dam)
                    .Include(blr => blr.Log!.Weather);
            }

            return baitLogs;
        }

        public override IQueryable<BaitLogRelationModel> ListQuery(bool includeNestedObjects = false) {
            IQueryable<BaitLogRelationModel> baitLogs = _databaseContext.BaitLogRelations
                .OrderBy(blr => blr.Bait!.Description)
                .ThenBy(blr => blr.Bait!.BrandId)
                .ThenBy(blr => blr.Bait!.BaitTypeId)
                .ThenBy(blr => blr.Log!.DamLocation!.DamId)
                .ThenBy(blr => blr.Log!.DamLocationId)
                .ThenBy(blr => blr.Log!.FishSpecieId);

            if (includeNestedObjects) {
                baitLogs
                    .Include(blr => blr.Bait)
                    .Include(blr => blr.Bait!.BrandId)
                    .Include(blr => blr.Bait!.BaitTypeId)
                    .Include(blr => blr.Log!.FishSpecie)
                    .Include(blr => blr.Log!.Rigs)
                    .Include(blr => blr.Log!.DamLocation)
                    .Include(blr => blr.Log!.DamLocation!.Dam)
                    .Include(blr => blr.Log!.Weather);
            }

            return baitLogs;
        }

        public async override Task<BaitLogRelationModel?> Remove(BaitLogRelationModel entity) {
            BaitLogRelationModel? dbEntry = await FindById(entity.Id);

            if (dbEntry != null) {
                _databaseContext.Remove(dbEntry);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public override async Task<BaitLogRelationModel?> Update(BaitLogRelationModel updatedEntity) {
            BaitLogRelationModel? dbEntry = await FindById(updatedEntity.Id);

            if (dbEntry != null) {
                dbEntry.BaitId = updatedEntity.BaitId;
                dbEntry.Bait = updatedEntity.Bait;
                dbEntry.LogId = updatedEntity.LogId;
                dbEntry.Log = updatedEntity.Log;

                _databaseContext.Update(dbEntry);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public override async Task<BaitLogRelationModel?> FindById(int id) {
            return await _databaseContext.BaitLogRelations
                .Where(blr => blr.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
