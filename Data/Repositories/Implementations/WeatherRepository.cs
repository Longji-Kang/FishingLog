using Fishing_API.Data.DBContexts;
using Fishing_API.Data.Repositories.Abstracts;
using Fishing_API.Data.Repositories.Interfaces;
using Fishing_API.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace Fishing_API.Data.Repositories.Implementations {
    public class WeatherRepository(DatabaseContext databaseContext) : FishingInterfaceAbstract<WeatherModel>, IWeatherRepository {
        private readonly DatabaseContext _databaseContext = databaseContext;

        public override async Task<WeatherModel?> Add(WeatherModel entity) {
            if (Find(entity) == null) {
                WeatherModel dbEntry = (await _databaseContext.Weather.AddAsync(entity)).Entity;
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public override async Task<WeatherModel?> Find(WeatherModel entity, bool includeNestedObjects = false) {
            return await _databaseContext.Weather
                .Where(w => w.Weather == entity.Weather)
                .FirstOrDefaultAsync();
        }

        public override async Task<WeatherModel?> FindById(int id) {
            return await _databaseContext.Weather
                .Where(w => w.Id == id)
                .FirstOrDefaultAsync();
        }

        public override IQueryable<WeatherModel> ListQuery(bool includeNestedObjects = false) {
            return _databaseContext.Weather
                .OrderBy(w => w.Weather);
        }

        public override async Task<WeatherModel?> Remove(WeatherModel entity) {
            WeatherModel? dbEntry = await FindById(entity.Id);

            if (dbEntry != null) {
                _databaseContext.Weather.Remove(dbEntry);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public override async Task<WeatherModel?> Update(WeatherModel updatedEntity) {
            WeatherModel? dbEntry = await FindById(updatedEntity.Id);

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
