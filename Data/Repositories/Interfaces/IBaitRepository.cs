using Fishing_API.Models.DatabaseModels;

namespace Fishing_API.Data.Repositories.Interfaces {
    public interface IBaitRepository : IFishingRepository<BaitModel> {
        public Task<BaitModel[]> ListBaitsByBrand(int brandId, BaitModel? lastEntity = default, bool includeNestedObjects = false, int pageSize = 10);
        public Task<BaitModel[]> ListBaitsByType(int typeId, BaitModel? lastEntity = default, bool includeNestedObjects = false, int pageSize = 10);
        public Task<BaitModel[]> ListBaitsByDescription(string description, BaitModel? lastEntity = default, bool includeNestedObjects = false, int pageSize = 10);
    }
}
