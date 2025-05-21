using Fishing_API.Models.ApiModels;
using Fishing_API.Models.DatabaseModels;

namespace Fishing_API.Data.Repositories.Interfaces {
    public interface IDamRepository : IFishingRepository<DamModel> {
        /*
         * Check currentPage <= totalPages at API level
         */
        public IQueryable<DamModel> ListByProvince(int provinceId, bool includeNestedObjects = false);
    }
}
