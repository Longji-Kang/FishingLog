using System.ComponentModel.DataAnnotations;

namespace Fishing_API.Models {
    public class WeatherModel {
        public int Id { get; set; }

        [Required]
        public string Weather { get; set; }
    }
}
