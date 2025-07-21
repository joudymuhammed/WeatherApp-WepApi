using WeatherApp.Data;      
using WeatherApp.DTOs.Weather;

namespace WeatherApp.Repos.WeatherRepo
{
    public class WeatherRepo:IWeatherRepo
    {
        private readonly ApplicationDbContext _context;

        public WeatherRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddWeather(WeatherRequestDto weatherDto)
        {
            var city = _context.Cities.FirstOrDefault(c => c.CityId == weatherDto.CityId);
            if (city == null)
            {
                throw new Exception($"City with ID {weatherDto.CityId} not found.");
            }

            var weather = new Entity.Weather
            {

                WeatherTemperature = weatherDto.WeatherTemperature,
                Humidity = weatherDto.Humidity,
                WindSpeed = weatherDto.WindSpeed,
                WeatherCondition = weatherDto.WeatherCondition,
                CityId = weatherDto.CityId 
            };

            _context.Weathers.Add(weather);
            _context.SaveChanges();
        


        }

        public WeatherResponseDto GetWeatherByCityId(int cityId)
        {
            var weather = _context.Weathers
                .Where(w => w.CityId == cityId)
                .Select(w => new WeatherResponseDto
                {
                    
                    WeatherId=w.WeatherId,
                    WeatherTemperature = w.WeatherTemperature,
                    Humidity = w.Humidity,
                    WindSpeed = w.WindSpeed,
                    WeatherCondition = w.WeatherCondition
                })
                .FirstOrDefault();

            return weather;
        }


        public void UpdateWeather(int id, WeatherRequestDto weatherDto)
        {
            var weather = _context.Weathers.FirstOrDefault(w => w.WeatherId == id);

            if (weather == null)
            {
                throw new Exception($" ID {id} not found.");
            }
            weather.WeatherTemperature = weatherDto.WeatherTemperature;
            weather.Humidity = weatherDto.Humidity;
            weather.WindSpeed = weatherDto.WindSpeed;
            weather.WeatherCondition = weatherDto.WeatherCondition;
            _context.Weathers.Update(weather);

            _context.SaveChanges();
        }
    }
}
