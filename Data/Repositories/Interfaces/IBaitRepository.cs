using Fishing_API.Models;

namespace Fishing_API.Data.Repositories.Interfaces {
    public interface IBaitRepository<T> : IFishingRepository<T> {
        public Task<T[]> ListBaitsByBrand(int brandId);
        public Task<T[]> ListBaitsByType(int typeId);
        public Task<T[]> ListBaitsByDescription(string description);
    }
}
