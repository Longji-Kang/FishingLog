using System.ComponentModel.DataAnnotations;

namespace Fishing_API.Models {
    public class DamModel {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required ProvinceModel Province { get; set; }
    }
}
