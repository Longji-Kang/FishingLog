using System.ComponentModel.DataAnnotations;

namespace Fishing_API.Models.DatabaseModels {
    public class FishSpeciesModel {
        public int Id { get; set; }
        [Required]
        public required string FishSpecie { get; set; }
    }
}
