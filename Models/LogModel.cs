using System.ComponentModel.DataAnnotations;

namespace Fishing_API.Models {
    public class LogModel {
        public int Id { get; set; }
        [Required]
        public required FishSpeciesModel FishSpecie {  get; set; }
        [Required]
        public required RigsModel Rigs { get; set; }
        [Required]
        public required DamLocationModel DamLocation { get; set; }
        [Required]
        public required WeatherModel Weather { get; set; }
        [Required]
        public required int Temperature { get; set; }
        [Required]
        public required DateOnly Day { get; set; }
        [Required]
        public required TimeOnly Time { get; set; }
    }
}
