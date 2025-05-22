using System.ComponentModel.DataAnnotations;

namespace Fishing_API.Models.DatabaseModels {
    public class DamLocationModel {
        public int Id { get; set; }
        [Required]
        public int DamId { get; set; }
        [Required]
        public DamModel? Dam { get; set; }
        [Required]
        public string? Location {  get; set; }
    }
}
