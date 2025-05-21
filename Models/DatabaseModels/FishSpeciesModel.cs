using System.ComponentModel.DataAnnotations;

namespace Fishing_API.Models.DatabaseModels {
    public class FishSpeciesModel {
        public int Id { get; set; }
        [Required]
        public string? FishSpecie { get; set; }
    }
}
