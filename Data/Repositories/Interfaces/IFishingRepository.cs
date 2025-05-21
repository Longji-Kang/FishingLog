using Fishing_API.Models.ApiModels;

namespace Fishing_API.Data.Repositories.Interfaces {
    //TODO revisit paging strategy, current strategy using PK ID won't work when ordering by other fields first
    public interface IFishingRepository<T> {
        public Task<T?> Add(T entity);
        public Task<T?> Remove(T entity);
        public Task<T?> Update(T entity, T updatedEntity);
        public Task<T?> Find(T entity, bool includeNestedObjects = false);
        /*
         * Check currentPage <= totalPages at API level
         * Default implementation for models with no nested objects
         */
        public Task<IQueryable<T>> ListQuery(bool includeNestedObjects = false);
        /*
         * Default implementation for models with no nested objects
         */
        public Task<PageListModel<T>> List(IQueryable<T> query, int currentPage, int pageSize = 20);
    }
}
