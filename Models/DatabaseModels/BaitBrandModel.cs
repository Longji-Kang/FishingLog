using System.ComponentModel.DataAnnotations;

namespace Fishing_API.Models.DatabaseModels {
    public class BaitBrandModel {
        public int Id { get; set; }
        [Required]
        public string? Brand {  get; set; }
    }
}
