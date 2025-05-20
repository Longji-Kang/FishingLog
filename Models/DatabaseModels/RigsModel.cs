using System.ComponentModel.DataAnnotations;

namespace Fishing_API.Models.DatabaseModels {
    public class RigsModel {
        public int Id { get; set; }
        [Required]
        public string RigName {  get; set; }
    }
}
