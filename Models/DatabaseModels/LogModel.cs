using System.ComponentModel.DataAnnotations;

namespace Fishing_API.Models.DatabaseModels {
    public class LogModel {
        public int Id { get; set; }
        [Required]
        public int FishSpecieId { get; set; }
        [Required]
        public FishSpeciesModel? FishSpecie {  get; set; }
        [Required]
        public int RigsId { get; set; }
        [Required]
        public RigsModel? Rigs { get; set; }
        [Required]
        public int DamLocationId { get; set; }
        [Required]
        public DamLocationModel? DamLocation { get; set; }
        [Required]
        public int WeatherId { get; set; }
        [Required]
        public WeatherModel? Weather { get; set; }
        [Required]
        public int Temperature { get; set; }
        [Required]
        public DateOnly Day { get; set; }
        [Required]
        public TimeOnly Time { get; set; }
    }
}
