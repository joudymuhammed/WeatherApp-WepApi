using System.ComponentModel.DataAnnotations;

namespace WeatherApp.DTOs.City
{
    public class CityRequestDto
    {
        [Required]
        public string CityName { get; set; }
        [Required]
        public string CityCountry { get; set; }
    }
}
