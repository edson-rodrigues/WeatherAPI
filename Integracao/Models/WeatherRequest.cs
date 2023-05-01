using Refit;

namespace Integracao.Models
{
    public class WeatherRequest
    {
        [AliasAs("lat")]
        public decimal Lat { get; set; }
        [AliasAs("lon")]
        public decimal Lng { get; set; }
        [AliasAs("appid")]
        public string? ApiKey { get; set; }
        [AliasAs("units")]
        public string Units { get; set; }
    }
}
