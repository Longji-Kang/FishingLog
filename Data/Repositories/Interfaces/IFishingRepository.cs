using Fishing_API.Models.ApiModels;
using Microsoft.EntityFrameworkCore;

namespace Fishing_API.Data.Repositories.Interfaces {
    //TODO revisit paging strategy, current strategy using PK ID won't work when ordering by other fields first
    public interface IFishingRepository<T> {
        public Task<T?> Add(T entity);
        public Task<T?> Remove(T entity);
        public Task<T?> Update(T entity, T updatedEntity);
        public Task<T?> Find(T entity, bool includeNestedObjects = false);
        /*
         * Check currentPage <= totalPages at API level
         */
        public Task<PageListModel<T>> List(int currentPage, bool includeNestedObjects = false, int pageSize = 20);
        /*
         * Default implementation for models with no nested objects
         */
        public async Task<PageListModel<T>> List(IQueryable<T> query, int currentPage, int pageSize = 20) {
            int total = (int)Math.Ceiling((float)await query.CountAsync() / pageSize);

            query
                .Skip((currentPage - total) * pageSize)
                .Take(pageSize);

            ICollection<T> data = await query.ToListAsync();

            return new PageListModel<T> {
                CurrentPage = currentPage,
                TotalPages = total,
                Data = data
            };
        }
    }
}
