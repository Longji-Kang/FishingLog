using Fishing_API.Data.DBContexts;
using Fishing_API.Data.Repositories.Abstracts;
using Fishing_API.Data.Repositories.Interfaces;
using Fishing_API.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace Fishing_API.Data.Repositories.Implementations {
    public class DamRepository(DatabaseContext databaseContext) : FishingInterfaceAbstract<DamModel>, IDamRepository {
        private readonly DatabaseContext _databaseContext = databaseContext;

        public override async Task<DamModel?> Add(DamModel entity) {
            if (Find(entity) == null) {
                DamModel dbEntry = (await _databaseContext.Dam.AddAsync(entity)).Entity;
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public override async Task<DamModel?> Find(DamModel entity, bool includeNestedObjects = false) {
            return await _databaseContext.Dam
                .Where(d => d.Name == entity.Name && d.ProvinceId == entity.ProvinceId)
                .FirstOrDefaultAsync();
        }

        public IQueryable<DamModel> ListByProvince(int provinceId, bool includeNestedObjects = false) {
            IQueryable<DamModel> dams = _databaseContext.Dam
                .Where(d => d.ProvinceId == provinceId)
                .OrderBy(d => d.Name);

            if (includeNestedObjects) {
                dams.Include(d => d.Province);
            }

            return dams;
        }

        public override IQueryable<DamModel> ListQuery(bool includeNestedObjects = false) {
            IQueryable<DamModel> dams = _databaseContext.Dam
                .OrderBy(d => d.ProvinceId)
                .ThenBy(d => d.Name);

            if (includeNestedObjects) {
                dams.Include(d => d.Province);
            }

            return dams;
        }

        public override async Task<DamModel?> Remove(DamModel entity) {
            DamModel? dbEntry = await Find(entity);

            if (dbEntry != null) {
                _databaseContext.Dam.Remove(dbEntry);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public override async Task<DamModel?> Update(DamModel entity, DamModel updatedEntity) {
            DamModel? dbEntry = await Find(entity);

            if (dbEntry != null) {
                dbEntry.Name = entity.Name;
                dbEntry.ProvinceId = entity.ProvinceId;
                dbEntry.Province = updatedEntity.Province;

                _databaseContext.Dam.Update(dbEntry);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }
    }
}
