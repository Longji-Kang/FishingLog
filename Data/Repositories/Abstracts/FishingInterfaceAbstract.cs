using Fishing_API.Data.Repositories.Interfaces;
using Fishing_API.Models.ApiModels.ResponseModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Fishing_API.Data.Repositories.Abstracts {
    public abstract class FishingInterfaceAbstract<T> : IFishingRepository<T> {
        public abstract Task<T?> Add(T entity);
        public abstract Task<T?> Find(T entity, bool includeNestedObjects = false);
        public abstract IQueryable<T> ListQuery(bool includeNestedObjects = false);
        public abstract Task<T?> Remove(int entityId);
        public abstract Task<T?> Update(T updatedEntity);     
        public async Task<PageListModel<T>> List(IQueryable<T> query, int currentPage, int pageSize = 20) {
            int total = (int)Math.Ceiling((float)await query.CountAsync() / pageSize);

            IQueryable<T> pagedQuery = query
                .Skip((total - (total - currentPage)) * pageSize)
                .Take(pageSize);

            ICollection<T> data = await pagedQuery.ToListAsync();

            return new PageListModel<T> {
                CurrentPage = currentPage + 1,
                TotalPages = total,
                PageSize = pageSize,
                Data = data
            };
        }

        public abstract Task<T?> FindById(int id);
    }
}
