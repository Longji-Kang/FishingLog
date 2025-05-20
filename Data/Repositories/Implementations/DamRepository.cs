using Fishing_API.Data.DBContexts;
using Fishing_API.Data.Repositories.Interfaces;
using Fishing_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Fishing_API.Data.Repositories.Implementations {
    public class DamRepository(DatabaseContext databaseContext) : IDamRepository {
        private readonly DatabaseContext _databaseContext = databaseContext;

        public async Task<DamModel?> Add(DamModel entity) {
            if (Find(entity) == null) {
                DamModel dbEntry = (await _databaseContext.Dam.AddAsync(entity)).Entity;
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public async Task<DamModel?> Find(DamModel entity, bool includeNestedObjects = false) {
            return await _databaseContext.Dam
                .Where(d => d.Name == entity.Name && d.ProvinceId == entity.ProvinceId)
                .FirstOrDefaultAsync();
        }

        public async Task<DamModel[]> List(DamModel? lastEntity = null, bool includeNestedObjects = false, int pageSize = 10) {
            IQueryable<DamModel> dams;

            if (lastEntity == null) {
                dams = _databaseContext.Dam
                    .OrderBy(d => d.ProvinceId)
                    .ThenBy(d => d.Name)
                    .Take(pageSize);
            } else {
                dams = _databaseContext.Dam
                    .Where(d => d.Id > lastEntity.Id)
                    .OrderBy(d => d.ProvinceId)
                    .ThenBy(d => d.Name)
                    .Take(pageSize);
            }

            if (includeNestedObjects) {
                dams.Include(d => d.Province);
            } 

            return await dams.ToArrayAsync();
        }

        public async Task<DamModel[]> ListByProvince(int provinceId, DamModel? lastEntity = null, bool includeNestedObjects = false, int pageSize = 10) {
            IQueryable<DamModel> dams;

            if (lastEntity == null) {
                dams = _databaseContext.Dam
                    .Where(d => d.ProvinceId == provinceId)
                    .OrderBy(d => d.ProvinceId)
                    .ThenBy(d => d.Name)
                    .Take(pageSize);
            } else {
                dams = _databaseContext.Dam
                    .Where(d => d.ProvinceId == provinceId && d.Id > lastEntity.Id)
                    .OrderBy(d => d.ProvinceId)
                    .ThenBy(d => d.Name)
                    .Take(pageSize);
            }

            if (includeNestedObjects) {
                dams.Include(d => d.Province);
            }

            return await dams.ToArrayAsync();
        }

        public async Task<DamModel?> Remove(DamModel entity) {
            DamModel? dbEntry = await Find(entity);

            if (dbEntry != null) {
                _databaseContext.Dam.Remove(dbEntry);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public async Task<DamModel?> Update(DamModel entity, DamModel updatedEntity) {
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
