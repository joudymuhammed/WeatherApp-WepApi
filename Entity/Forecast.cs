using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Entity
{
    public class Forecast
    {
        public int ForecastId { get; set; }

        [Required]
        public DateTime Date { get; set; }
        [Required]
        public float Temperature { get; set; }
        [Required]
        public string Condition { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }
    }
}
