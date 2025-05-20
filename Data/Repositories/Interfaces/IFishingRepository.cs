using Fishing_API.Models.ApiModels;
using Microsoft.EntityFrameworkCore;

namespace Fishing_API.Data.Repositories.Interfaces {
    //TODO revisit paging strategy, current strategy using PK ID won't work when ordering by other fields first
    public interface IFishingRepository<T> {
        public Task<T?> Add(T entity);
        public Task<T?> Remove(T entity);
        public Task<T?> Update(T entity, T updatedEntity);
        public Task<T?> Find(T entity, bool includeNestedObjects = false);
        public Task<PageListModel<T>> List(int currentPage, bool includeNestedObjects = false, int pageSize = 10);
    }
}
