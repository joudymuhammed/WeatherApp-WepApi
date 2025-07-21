using System.ComponentModel.DataAnnotations;

namespace WeatherApp.DTOs.Forecast
{
    public class ForecastResponseDto
    {
        public int ForecastId { get; set; }
        public int CityId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public float Temperature { get; set; }
        [Required]
        public string Condition { get; set; }
        
    }
}
