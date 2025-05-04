using System.ComponentModel.DataAnnotations;

namespace Fishing_API.Models {
    public class DamLocationModel {
        public int Id { get; set; }
        [Required]
        public required DamModel Dam { get; set; }
        [Required]
        public required string Location {  get; set; }
    }
}
