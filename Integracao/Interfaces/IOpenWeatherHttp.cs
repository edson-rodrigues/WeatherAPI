using Integracao.Models;
using Refit;
namespace Integracao.Interfaces
{
    public interface IOpenWeatherHttp
    {
        [Get("/data/2.5/weather")]
        Task<IApiResponse<WeatherResponse>> GetWeather([Query] WeatherRequest weatherRequest);
    }
}
