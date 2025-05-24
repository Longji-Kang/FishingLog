using Fishing_API.Data.Repositories.Interfaces;
using Fishing_API.Models.ApiModels.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace Fishing_API.Data.Repositories.Abstracts {
    public abstract class FishingInterfaceAbstract<T> : IFishingRepository<T> {
        public abstract Task<T?> Add(T entity);
        public abstract Task<T?> Find(T entity, bool includeNestedObjects = false);
        public abstract IQueryable<T> ListQuery(bool includeNestedObjects = false);
        public abstract Task<T?> Remove(T entity);
        public abstract Task<T?> Update(T updatedEntity);
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

        public abstract Task<T?> FindById(int id);
    }
}
