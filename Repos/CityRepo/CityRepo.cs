using Microsoft.EntityFrameworkCore;
using WeatherApp.Data;
using WeatherApp.Entity;
using WeatherApp.DTOs.City;
using WeatherApp.DTOs.Forecast;
using WeatherApp.DTOs.Weather;
using WeatherApp.Repos.CityRepo;

namespace WeatherApp.Repos.City
{
    public class CityRepo : ICityRepo
    {
        private readonly ApplicationDbContext _context;

        public CityRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<CityResponseDto> GetAllCities()
        {
            var cities = _context.Cities
                .Include(c => c.Weather)
                .Include(c => c.Forecasts)
                .Select(city => new CityResponseDto{

                CityName = city.CityName,
                CityCountry = city.CityCountry,
                WeatherDto = new WeatherRequestDto
                {
                    

                    WeatherTemperature = city.Weather.WeatherTemperature,
                    Humidity = city.Weather.Humidity,
                    WeatherCondition = city.Weather.WeatherCondition
                },
                ForecastsDto = city.Forecasts.Select(forecast => new ForecastForCityDto
                {
                    Date = forecast.Date,
                    Temperature = forecast.Temperature,
                    Condition = forecast.Condition
                }).ToList()
            }).ToList();

            return cities;
        }

        public CityResponseDto GetCityById(int id)
        {
            var city = _context.Cities
                .Include(c => c.Weather)
                .Include(c => c.Forecasts)
                .FirstOrDefault(c => c.CityId == id);

            var cityDto = new CityResponseDto
            {
                CityName = city.CityName,
                CityCountry = city.CityCountry,
                WeatherDto = new WeatherRequestDto
                {
                    Humidity = city.Weather.Humidity,
                    WindSpeed = city.Weather.WindSpeed,

                    WeatherCondition = city.Weather.WeatherCondition
                },
                ForecastsDto = city.Forecasts.Select(forecast => new ForecastForCityDto
                {
                    Date = forecast.Date,
                    Temperature = forecast.Temperature,
                }).ToList()
            };

            return cityDto;
        }

        public void AddCity(CityRequestDto cityRequestDto)
        {
            var city = new  Entity.City
            {
                CityName = cityRequestDto.CityName,
                CityCountry = cityRequestDto.CityCountry
                
            };
            _context.Cities.Add(city);
            _context.SaveChanges();
        }
    }
}

