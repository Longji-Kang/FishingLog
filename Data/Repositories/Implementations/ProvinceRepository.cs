using Fishing_API.Data.DBContexts;
using Fishing_API.Data.Repositories.Abstracts;
using Fishing_API.Data.Repositories.Interfaces;
using Fishing_API.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace Fishing_API.Data.Repositories.Implementations {
    public class ProvinceRepository(DatabaseContext databaseContext) : FishingInterfaceAbstract<ProvinceModel> {
        private readonly DatabaseContext _databaseContext = databaseContext;

        /*
         * Provinces won't be added
         */
        public override Task<ProvinceModel?> Add(ProvinceModel entity) {
            throw new NotSupportedException();
        }

        public override async Task<ProvinceModel?> Find(ProvinceModel entity, bool includeNestedObjects = false) {
            return await _databaseContext.Provinces
                .Where(p => p.ProvinceName == entity.ProvinceName)
                .FirstOrDefaultAsync();
        }

        public override IQueryable<ProvinceModel> ListQuery(bool includeNestedObjects = false) {
            return _databaseContext.Provinces
                .OrderBy(p => p.ProvinceName);
        }

        /*
         * Provinces won't be removed
         */
        public override Task<ProvinceModel?> Remove(ProvinceModel entity) {
            throw new NotSupportedException();
        }

        /*
         * Provinces won't be updated
         */
        public override Task<ProvinceModel?> Update(ProvinceModel entity, ProvinceModel updatedEntity) {
            throw new NotSupportedException();
        }
    }
}
