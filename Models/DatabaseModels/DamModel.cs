using System.ComponentModel.DataAnnotations;

namespace Fishing_API.Models.DatabaseModels {
    public class DamModel {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ProvinceId { get; set; }
        [Required]
        public  ProvinceModel Province { get; set; }
    }
}
