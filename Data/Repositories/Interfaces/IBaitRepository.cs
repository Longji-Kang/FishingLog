using Fishing_API.Models.ApiModels;
using Fishing_API.Models.DatabaseModels;

namespace Fishing_API.Data.Repositories.Interfaces {
    public interface IBaitRepository : IFishingRepository<BaitModel> {
        public Task<PageListModel<BaitModel>> ListBaitsByBrand(int brandId, int currentPage, bool includeNestedObjects = false, int pageSize = 10);
        public Task<PageListModel<BaitModel>> ListBaitsByType(int typeId, int currentPage, bool includeNestedObjects = false, int pageSize = 10);
        public Task<PageListModel<BaitModel>> ListBaitsByDescription(string description, int currentPage, bool includeNestedObjects = false, int pageSize = 10);
    }
}