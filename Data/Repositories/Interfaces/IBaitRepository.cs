using Fishing_API.Models.ApiModels;
using Fishing_API.Models.DatabaseModels;

namespace Fishing_API.Data.Repositories.Interfaces {
    public interface IBaitRepository : IFishingRepository<BaitModel> {
        public Task<PageListModel<BaitModel>> ListBaitsByBrand(int brandId, BaitModel? lastEntity = default, bool includeNestedObjects = false, int pageSize = 10);
        public Task<PageListModel<BaitModel>> ListBaitsByType(int typeId, BaitModel? lastEntity = default, bool includeNestedObjects = false, int pageSize = 10);
        public Task<PageListModel<BaitModel>> ListBaitsByDescription(string description, BaitModel? lastEntity = default, bool includeNestedObjects = false, int pageSize = 10);
    }
}