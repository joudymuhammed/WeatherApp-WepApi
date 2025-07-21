using System.ComponentModel.DataAnnotations;
using WeatherApp.DTOs.Forecast;
using WeatherApp.DTOs.Weather;

namespace WeatherApp.DTOs.City
{
    public class CityResponseDto
    {
        [Required]
        public string CityName { get; set; }
        [Required]
        public string CityCountry { get; set; }
        public WeatherRequestDto WeatherDto { get; set; }
        public List<ForecastForCityDto> ForecastsDto { get; set; }
    }
}
