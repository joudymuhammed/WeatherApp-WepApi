using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Entity
{
    public class City
    {
        public int CityId { get; set; }
        [Required]
        public string CityName { get; set; }
        [Required]
        public string CityCountry { get; set; } 
        public List<Forecast>? Forecasts { get; set; }
        public Weather? Weather { get; set; }
    }
}
