using Fishing_API.Models.ApiModels;
using Fishing_API.Models.DatabaseModels;

namespace Fishing_API.Data.Repositories.Interfaces {
    public interface IBaitRepository : IFishingRepository<BaitModel> {
        /*
         * Check currentPage <= totalPages at API level
         */
        public Task<PageListModel<BaitModel>> ListBaitsByBrand(int brandId, int currentPage, bool includeNestedObjects = false, int pageSize = 20);
        /*
         * Check currentPage <= totalPages at API level
         */
        public Task<PageListModel<BaitModel>> ListBaitsByType(int typeId, int currentPage, bool includeNestedObjects = false, int pageSize = 20);
        /*
         * Check currentPage <= totalPages at API level
         */
        public Task<PageListModel<BaitModel>> ListBaitsByDescription(string description, int currentPage, bool includeNestedObjects = false, int pageSize = 20);
    }
}