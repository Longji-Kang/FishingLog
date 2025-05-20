using Fishing_API.Models;

namespace Fishing_API.Data.Repositories.Interfaces {
    public interface IDamLocationRepository : IFishingRepository<DamLocationModel> {
        public Task<DamLocationModel[]> ListByDam(int damId, DamLocationModel? lastEntity = null, bool includeNestedObjects = false, int pageSize = 10);
    }
}
