using Fishing_API.Data.DBContexts;
using Fishing_API.Data.Repositories.Interfaces;
using Fishing_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Fishing_API.Data.Repositories.Implementations {
    public class ProvinceRepository(DatabaseContext databaseContext) : IFishingRepository<ProvinceModel> {
        private readonly DatabaseContext _databaseContext = databaseContext;

        /*
         * Provinces won't be added
         */
        public Task<ProvinceModel?> Add(ProvinceModel entity) {
            throw new NotImplementedException();
        }

        public async Task<ProvinceModel?> Find(ProvinceModel entity, bool includeNestedObjects = false) {
            return await _databaseContext.Provinces
                .Where(p => p.ProvinceName == entity.ProvinceName)
                .FirstOrDefaultAsync();
        }

        /*
         * Only 9 provinces so last entity and page size will be irrelevant
         */
        public async Task<ProvinceModel[]> List(ProvinceModel? lastEntity = null, bool includeNestedObjects = false, int pageSize = 10) {
            return await _databaseContext.Provinces
                .ToArrayAsync();
        }

        /*
         * Provinces won't be removed
         */
        public Task<ProvinceModel?> Remove(ProvinceModel entity) {
            throw new NotImplementedException();
        }

        /*
         * Provinces won't be updated
         */
        public Task<ProvinceModel?> Update(ProvinceModel entity, ProvinceModel updatedEntity) {
            throw new NotImplementedException();
        }
    }
}
