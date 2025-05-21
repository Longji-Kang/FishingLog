using System.ComponentModel.DataAnnotations;

namespace Fishing_API.Models.DatabaseModels {
    public class BaitTypeModel {
        public int Id { get; set; }
        [Required]
        public string? Type { get; set; }
    }
}
