using Integracao.Interfaces;
using Integracao.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Web;
using System.Text.Encodings.Web;

namespace WeatherAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IOpenWeatherHttp _openWeatherHttp;
        private IOpenGeoHttp OpenGeoHttp;
        private readonly IConfiguration _configuration;

        public WeatherController(IOpenWeatherHttp openWeatherHttp, IConfiguration configuration, IOpenGeoHttp openGeoHttp)
        {
            _openWeatherHttp = openWeatherHttp;
            _configuration = configuration;
            OpenGeoHttp = openGeoHttp;
        }

        [HttpGet("/get-temperature")]
        public async Task<ActionResult<double>> GetTemperature(string cityName)
        {
            //var cityEncoded = UrlEncode(cityName);
            var coordenates = await OpenGeoHttp.GetCoordenates(cityName, _configuration["Secrets:ApiKey"]);

            if (coordenates.IsSuccessStatusCode)
            {
                if (coordenates.Content.Any())
                {
                    var request = new WeatherRequest
                    {
                        Lat = coordenates.Content.First().Lat,
                        Lng = coordenates.Content.First().Lon,
                        ApiKey = _configuration["Secrets:ApiKey"],
                        Units = "metric"
                    };

                    var response = await _openWeatherHttp.GetWeather(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var weatherResponse = response.Content;
                        var temperature = weatherResponse.Main.Temp;
                        return Ok(temperature);
                    }
                    else
                    {
                        return StatusCode((int)response.StatusCode);
                    }
                }
                else
                {
                    throw new Exception("Nenhuma Cidade com esse nome foi encontrada");
                }
            }

            else
            {
                return StatusCode((int)coordenates.StatusCode);
            }

        }
    }
}
