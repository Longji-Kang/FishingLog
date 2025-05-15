using System.ComponentModel.DataAnnotations;

namespace Fishing_API.Models {
    public class BaitLogRelationModel {
        public int Id { get; set; }

        [Required]
        public int BaitId { get; set; }
        [Required]
        public required BaitModel Bait { get; set; }
        [Required]
        public int LogId { get; set; }
        [Required]
        public required LogModel Log { get; set; }
    }
}
