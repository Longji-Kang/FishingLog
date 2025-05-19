using Microsoft.EntityFrameworkCore;

namespace Fishing_API.Data.Repositories.Interfaces {
    public interface IFishingRepository<T> {
        public Task<T?> Add(T entity);
        public Task<T?> Remove(T entity);
        public Task<T?> Update(T entity, T updatedEntity);
        public Task<T?> Find(T entity, bool includeNestedObjects = false);
        public Task<T[]> List(T? lastEntity = default, bool includeNestedObjects = false, int pageSize = 10);
    }
}
