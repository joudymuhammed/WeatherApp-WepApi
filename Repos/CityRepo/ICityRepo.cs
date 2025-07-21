using WeatherApp.DTOs.City;

namespace WeatherApp.Repos.CityRepo
{
    public interface ICityRepo
    {
        List<CityResponseDto> GetAllCities();
        CityResponseDto GetCityById(int id);
        public void AddCity(CityRequestDto cityRequestDto);


    }
}
