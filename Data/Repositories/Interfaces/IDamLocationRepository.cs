using Fishing_API.Models.ApiModels;
using Fishing_API.Models.DatabaseModels;

namespace Fishing_API.Data.Repositories.Interfaces {
    public interface IDamLocationRepository : IFishingRepository<DamLocationModel> {
        public Task<PageListModel<DamLocationModel>> ListByDam(int damId, int currentPage, bool includeNestedObjects = false, int pageSize = 10);
    }
}
