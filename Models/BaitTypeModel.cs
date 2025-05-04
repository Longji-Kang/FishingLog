using System.ComponentModel.DataAnnotations;

namespace Fishing_API.Models {
    public class BaitTypeModel {
        public int Id { get; set; }
        [Required]
        public required string Type { get; set; }
    }
}
