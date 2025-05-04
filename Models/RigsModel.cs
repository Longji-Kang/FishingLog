using System.ComponentModel.DataAnnotations;

namespace Fishing_API.Models {
    public class RigsModel {
        public int Id { get; set; }
        [Required]
        public required string RigName {  get; set; }
    }
}
