using Fishing_API.Models.ApiModels;
using Fishing_API.Models.DatabaseModels;

namespace Fishing_API.Data.Repositories.Interfaces {
    public interface IDamLocationRepository : IFishingRepository<DamLocationModel> {
        /*
         * Check currentPage <= totalPages at API level
         */
        public IQueryable<DamLocationModel> ListByDam(int damId, bool includeNestedObjects = false);
    }
}
