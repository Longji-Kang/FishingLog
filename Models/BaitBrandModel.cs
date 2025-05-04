using System.ComponentModel.DataAnnotations;

namespace Fishing_API.Models {
    public class BaitBrandModel {
        public int Id { get; set; }
        [Required]
        public required string Brand {  get; set; }
    }
}
