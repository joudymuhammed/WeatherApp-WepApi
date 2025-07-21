using System.ComponentModel.DataAnnotations;

namespace WeatherApp.DTOs.Weather
{
    public class WeatherResponseDto
    {
        public int WeatherId { get; set; }
        [Required]
        public float WeatherTemperature { get; set; }
        [Required]
        public int Humidity { get; set; }
        [Required]
        public float WindSpeed { get; set; }
        [Required]
        public string WeatherCondition { get; set; }
    }
}
