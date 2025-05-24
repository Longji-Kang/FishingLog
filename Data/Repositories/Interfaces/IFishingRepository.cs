using Fishing_API.Models.ApiModels.ResponseModels;

namespace Fishing_API.Data.Repositories.Interfaces {
    public interface IFishingRepository<T> {
        public Task<T?> Add(T entity);
        public Task<T?> Remove(T entity);
        public Task<T?> Update(T updatedEntity);
        public Task<T?> Find(T entity, bool includeNestedObjects = false);
        public Task<T?> FindById(int id);
        /*
         * Check currentPage <= totalPages at API level
         * Default implementation for models with no nested objects
         */
        public IQueryable<T> ListQuery(bool includeNestedObjects = false);
        /*
         * Default implementation for models with no nested objects
         */
        public Task<PageListModel<T>> List(IQueryable<T> query, int currentPage, int pageSize = 20);
    }
}
