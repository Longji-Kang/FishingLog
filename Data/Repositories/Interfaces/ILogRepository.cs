using Fishing_API.Models.DatabaseModels;

namespace Fishing_API.Data.Repositories.Interfaces {
    public interface ILogRepository : IFishingRepository<LogModel> {
        public IQueryable<LogModel> ListBySpecies(int specieId, bool includeNestedObjects);
        public IQueryable<LogModel> ListByRigs(int rigId, bool includeNestedObjects);
        public IQueryable<LogModel> ListByDamLocation(int damLocationId, bool includeNestedObjects);
        public IQueryable<LogModel> ListByDam(int damId, bool includeNestedObjects);
        public IQueryable<LogModel> ListByWeather(int weatherId, bool includeNestedObjects);
        public IQueryable<LogModel> ListByTemperature(int temperatureId, bool includeNestedObjects);
        public IQueryable<LogModel> ListByDay(DateOnly day, bool includeNestedObjects);
        public IQueryable<LogModel> ListByTime(TimeOnly time, bool includeNestedObjects);
    }
}
