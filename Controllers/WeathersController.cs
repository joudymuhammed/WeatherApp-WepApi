﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.DTOs.Weather;
using WeatherApp.Repos.WeatherRepo;

namespace WeatherApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeathersController : ControllerBase
    {
        private readonly IWeatherRepo _weatherRepo;

        public WeathersController(IWeatherRepo weatherRepo)
        {
            _weatherRepo = weatherRepo;
        }

        [HttpGet("{cityId}")]
        public IActionResult GetWeatherByCityId(int cityId)
        {
            
            var weather = _weatherRepo.GetWeatherByCityId(cityId);
            if (weather == null)
            {
                return NotFound(new { message = $"Weather data not found for city ID {cityId}" });
            }

            return Ok(weather); 
            
            
        }
        [HttpPost]
        public IActionResult AddWeather( WeatherRequestDto weatherDto)
        {
            try
            {
                _weatherRepo.AddWeather(weatherDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateWeather(int id, WeatherRequestDto weatherDto)
        {
            
            _weatherRepo.UpdateWeather(id, weatherDto);
            return NoContent(); 
            
        }
    }
}

