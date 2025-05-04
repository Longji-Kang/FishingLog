using System.ComponentModel.DataAnnotations;

namespace Fishing_API.Models {
    public class BaitModel {
        public int Id { get; set; }
        [Required]
        public required BaitBrandModel Brand { get; set; }
        [Required]
        public required BaitTypeModel BaitType { get; set; }
        [Required]
        public required string Description { get; set; }
    }
}
