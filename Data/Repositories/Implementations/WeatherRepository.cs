using Fishing_API.Data.DBContexts;
using Fishing_API.Data.Repositories.Interfaces;
using Fishing_API.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace Fishing_API.Data.Repositories.Implementations {
    public class WeatherRepository(DatabaseContext databaseContext) : IFishingRepository<WeatherModel> {
        private readonly DatabaseContext _databaseContext = databaseContext;

        public async Task<WeatherModel?> Add(WeatherModel entity) {
            if (Find(entity) == null) {
                WeatherModel dbEntry = (await _databaseContext.Weather.AddAsync(entity)).Entity;
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public async Task<WeatherModel?> Find(WeatherModel entity, bool includeNestedObjects = false) {
            return await _databaseContext.Weather
                .Where(w => w.Weather == entity.Weather)
                .FirstOrDefaultAsync();
        }

        public async Task<WeatherModel[]> List(WeatherModel? lastEntity = null, bool includeNestedObjects = false, int pageSize = 10) {
            IQueryable<WeatherModel> weather;

            if (lastEntity == null) {
                weather = _databaseContext.Weather
                    .OrderBy(w => w.Weather)
                    .ThenBy(w => w.Id)
                    .Take(pageSize);
            } else {
                weather = _databaseContext.Weather
                    .Where(w => w.Id > lastEntity.Id)
                    .OrderBy(w => w.Weather)
                    .ThenBy(w => w.Id)
                    .Take(pageSize);
            }

            return await weather.ToArrayAsync();
        }

        public async Task<WeatherModel?> Remove(WeatherModel entity) {
            WeatherModel? dbEntry = await Find(entity);

            if (dbEntry != null) {
                _databaseContext.Weather.Remove(dbEntry);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public async Task<WeatherModel?> Update(WeatherModel entity, WeatherModel updatedEntity) {
            WeatherModel? dbEntry = await Find(entity);

            if (dbEntry != null) {
                dbEntry.Weather = updatedEntity.Weather;

                _databaseContext.Weather.Update(dbEntry);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }
    }
}
