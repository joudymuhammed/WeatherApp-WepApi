using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Entity
{
    public class Weather
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
        public int CityId { get; set; }
        public City City { get; set; }

    }
}
