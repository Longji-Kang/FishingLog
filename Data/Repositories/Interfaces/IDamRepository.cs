using Fishing_API.Models.DatabaseModels;

namespace Fishing_API.Data.Repositories.Interfaces {
    public interface IDamRepository : IFishingRepository<DamModel> {
        public Task<DamModel[]> ListByProvince(int provinceId, DamModel? lastEntity = default, bool includeNestedObjects = false, int pageSize = 10);
    }
}
