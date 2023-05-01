using Integracao.Interfaces;
using Integracao.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace WeatherAPI.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IOpenWeatherHttp _openWeatherHttp;
        private readonly IConfiguration _configuration;
 
        public WeatherController(IOpenWeatherHttp openWeatherHttp, IConfiguration configuration)
        {
            _openWeatherHttp = openWeatherHttp;
            _configuration = configuration;
        }

        [HttpGet("/{lat}/{lon}/{units}")]
        public async Task<ActionResult<double>> GetTemperature(decimal lat, decimal lon, string key)
        {
            var request = new WeatherRequest
            {
                Lat = lat,
                Lng = lon,
                ApiKey = _configuration["Secrets:ApiKey"]
            };
            var response = await _openWeatherHttp.GetWeather(request);
            if(response.IsSuccessStatusCode)
            {
                var responseBody = response.Content;
                var temperature = responseBody.GetProperty("main").GetProperty("temp").GetDecimal;
                return Ok(temperature);
            }
            else
            {
                return StatusCode((int) response.StatusCode);
            }
        }
    }
}
