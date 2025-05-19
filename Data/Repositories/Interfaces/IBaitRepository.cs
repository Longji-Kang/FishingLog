using Fishing_API.Models;

namespace Fishing_API.Data.Repositories.Interfaces {
    public interface IBaitRepository<T> : IFishingRepository<T> {
        public Task<T[]> ListBaitsByBrand(int brandId, T? lastEntity = default, bool includeNestedObjects = false, int pageSize = 10);
        public Task<T[]> ListBaitsByType(int typeId, T? lastEntity = default, bool includeNestedObjects = false, int pageSize = 10);
        public Task<T[]> ListBaitsByDescription(string description, T? lastEntity = default, bool includeNestedObjects = false, int pageSize = 10);
    }
}
