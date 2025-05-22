using System.ComponentModel.DataAnnotations;

namespace Fishing_API.Models.DatabaseModels {
    public class BaitModel {
        public int Id { get; set; }
        [Required]
        public int BrandId { get; set; }
        [Required]
        public BaitBrandModel? Brand { get; set; }
        [Required]
        public int BaitTypeId { get; set; }
        [Required]
        public BaitTypeModel? BaitType { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
