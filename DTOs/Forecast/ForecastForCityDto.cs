using System.ComponentModel.DataAnnotations;

namespace WeatherApp.DTOs.Forecast
{
    public class ForecastForCityDto
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public float Temperature { get; set; }
        [Required]
        public string Condition { get; set; }
    }
}
