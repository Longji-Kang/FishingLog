using Fishing_API.Models.ApiModels;
using Fishing_API.Models.DatabaseModels;

namespace Fishing_API.Data.Repositories.Interfaces {
    public interface IBaitRepository : IFishingRepository<BaitModel> {
        /*
         * Check currentPage <= totalPages at API level
         */
        public IQueryable<BaitModel> ListBaitsByBrand(int brandId, bool includeNestedObjects = false);
        /*
         * Check currentPage <= totalPages at API level
         */
        public IQueryable<BaitModel> ListBaitsByType(int typeId, bool includeNestedObjects = false);
        /*
         * Check currentPage <= totalPages at API level
         */
        public IQueryable<BaitModel> ListBaitsByDescription(string description, bool includeNestedObjects = false);
    }
}