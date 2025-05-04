using System.ComponentModel.DataAnnotations;

namespace Fishing_API.Models {
    public class ProvinceModel {
        public int Id { get; set; }
        [Required]
        public required string ProvinceName { get; set; }
    }
}
