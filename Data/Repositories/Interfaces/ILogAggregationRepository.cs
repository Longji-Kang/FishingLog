using Fishing_API.Models.DatabaseModels;

namespace Fishing_API.Data.Repositories.Interfaces {
    public interface ILogAggregationRepository : IFishingRepository<BaitLogRelationModel> {
        public IQueryable<BaitLogRelationModel> ListByBaitDescription(string baitDesc, bool includeNestedObjects);
        public IQueryable<BaitLogRelationModel> ListByBaitBrand(int brandId, bool includeNestedObjects);
        public IQueryable<BaitLogRelationModel> ListByDam(int damId, bool includeNestedObjects);
        public IQueryable<BaitLogRelationModel> ListByBaitType(int baitTypeId, bool includeNestedObjects);
        public IQueryable<BaitLogRelationModel> ListBySpecies(int speciesId, bool includeNestedObjects);
    }
}
