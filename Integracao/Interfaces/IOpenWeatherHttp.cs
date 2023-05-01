using Integracao.Models;
using Refit;
using System.Text.Json;

namespace Integracao.Interfaces
{
    public interface IOpenWeatherHttp
    {
        [Get("/data/2.5/weather")]
        Task<IApiResponse<JsonElement>> GetWeather([Query] WeatherRequest weatherRequest);
    }
}
