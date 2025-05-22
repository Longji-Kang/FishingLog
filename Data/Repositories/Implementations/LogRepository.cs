using Fishing_API.Data.DBContexts;
using Fishing_API.Data.Repositories.Abstracts;
using Fishing_API.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace Fishing_API.Data.Repositories.Implementations {
    public class LogRepository(DatabaseContext databaseContext) : FishingInterfaceAbstract<LogModel> {
        private readonly DatabaseContext _databaseContext = databaseContext;

        public override async Task<LogModel?> Add(LogModel entity) {
            if (Find(entity) == null) {
                LogModel dbEntry = (await _databaseContext.Logs.AddAsync(entity)).Entity;
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public override async Task<LogModel?> Find(LogModel entity, bool includeNestedObjects = false) {
            return await _databaseContext.Logs
                .Where(l =>
                    l.FishSpecieId == entity.FishSpecieId &&
                    l.RigsId == entity.RigsId &&
                    l.DamLocationId == entity.DamLocationId &&
                    l.WeatherId == entity.WeatherId &&
                    l.Temperature == entity.Temperature &&
                    l.Day == entity.Day &&
                    l.Time == entity.Time 
                )
                .FirstOrDefaultAsync();
        }

        public override IQueryable<LogModel> ListQuery(bool includeNestedObjects = false) {
            IQueryable<LogModel> logs = _databaseContext.Logs
                .OrderBy(l => l.DamLocation!.DamId)
                .ThenBy(l => l.DamLocationId)
                .ThenBy(l => l.FishSpecieId)
                .ThenBy(l => l.Rigs)
                .ThenBy(l => l.WeatherId)
                .ThenBy(l => l.Temperature)
                .ThenBy(l => l.Day)
                .ThenBy(l => l.Time);

            if (includeNestedObjects) {
                logs
                    .Include(l => l.FishSpecie)
                    .Include(l => l.Rigs)
                    .Include(l => l.DamLocation)
                    .Include(l => l.DamLocation!.Dam)
                    .Include(l => l.Weather);
            }

            return logs;
        }

        public override async Task<LogModel?> Remove(LogModel entity) {
            LogModel? dbEntry = await Find(entity);

            if (dbEntry != null) {
                _databaseContext.Remove(dbEntry);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public override async Task<LogModel?> Update(LogModel entity, LogModel updatedEntity) {
            LogModel? dbEntry = await Find(entity);

            if (dbEntry != null) {
                dbEntry.FishSpecieId = updatedEntity.FishSpecieId;
                dbEntry.FishSpecie = updatedEntity.FishSpecie;
                dbEntry.RigsId = updatedEntity.RigsId;
                dbEntry.Rigs = updatedEntity.Rigs;
                dbEntry.DamLocationId = updatedEntity.DamLocationId;
                dbEntry.DamLocation = updatedEntity.DamLocation;
                dbEntry.WeatherId = updatedEntity.WeatherId;
                dbEntry.Weather = updatedEntity.Weather;
                dbEntry.Temperature = updatedEntity.Temperature;
                dbEntry.Day = updatedEntity.Day;
                dbEntry.Time = updatedEntity.Time;

                _databaseContext.Update(dbEntry);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }
    }
}
