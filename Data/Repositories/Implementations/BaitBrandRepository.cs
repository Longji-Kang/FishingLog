using Fishing_API.Data.DBContexts;
using Fishing_API.Data.Repositories.Interfaces;
using Fishing_API.Models.ApiModels;
using Fishing_API.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace Fishing_API.Data.Repositories.Implementations {
    public class BaitBrandRepository : IFishingRepository<BaitBrandModel> {
        private readonly DatabaseContext _databaseContext;

        public BaitBrandRepository(DatabaseContext databaseContext) {
            _databaseContext = databaseContext;
        }

        public async Task<BaitBrandModel?> Add(BaitBrandModel entity) {
            if (Find(entity) == null) {
                BaitBrandModel dbEntry = (await _databaseContext.BaitBrands.AddAsync(entity)).Entity;
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public async Task<BaitBrandModel?> Remove(BaitBrandModel entity) {
            BaitBrandModel? dbEntry = await Find(entity);

            if (dbEntry != null) {
                _databaseContext.BaitBrands.Remove(dbEntry);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public async Task<BaitBrandModel?> Update(BaitBrandModel entity, BaitBrandModel updatedEntity) {
            BaitBrandModel? dbEntry = await Find(entity);

            if (dbEntry != null) {
                dbEntry.Brand = updatedEntity.Brand;

                _databaseContext.BaitBrands.Update(dbEntry);
                await _databaseContext.SaveChangesAsync();

                return dbEntry;
            } else {
                return null;
            }
        }

        public async Task<BaitBrandModel?> Find(BaitBrandModel entity, bool includeNestedObjects = false) {
            BaitBrandModel? baitBrand = await _databaseContext.BaitBrands
                .Where(b => b.Brand == entity.Brand)
                .FirstOrDefaultAsync();

            return baitBrand;
        }

        /*
         * Check currentPage <= totalPages at API level
         */
        public async Task<PageListModel<BaitBrandModel>> List(int currentPage, bool includeNestedObjects = false, int pageSize = 20) {
            IQueryable<BaitBrandModel> brands = _databaseContext.BaitBrands
                .OrderBy(b => b.Brand);

            int totalPages = (int)Math.Ceiling((float)(await brands.CountAsync()) / pageSize);

            brands
                .Skip((currentPage - 1) * pageSize)
                .Take(totalPages);

            ICollection<BaitBrandModel> data = await brands.ToListAsync();

            return new PageListModel<BaitBrandModel>{
                CurrentPage = currentPage,
                TotalPages = totalPages,
                Data = data
            };
        }
    }
}
