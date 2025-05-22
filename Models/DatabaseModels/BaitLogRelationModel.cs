using System.ComponentModel.DataAnnotations;

namespace Fishing_API.Models.DatabaseModels {
    public class BaitLogRelationModel {
        public int Id { get; set; }

        [Required]
        public int BaitId { get; set; }
        [Required]
        public BaitModel? Bait { get; set; }
        [Required]
        public int LogId { get; set; }
        [Required]
        public LogModel? Log { get; set; }
    }
}
