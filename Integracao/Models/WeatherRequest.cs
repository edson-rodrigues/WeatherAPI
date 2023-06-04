using Refit;

namespace Integracao.Models
{
    public class WeatherRequest
    {
        [AliasAs("lat")]
        public double Lat { get; set; }
        [AliasAs("lon")]
        public double Lng { get; set; }
        [AliasAs("appid")]
        public string? ApiKey { get; set; }
        [AliasAs("units")]
        public string Units { get; set; }
    }
}
