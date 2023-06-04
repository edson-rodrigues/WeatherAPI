using System.Text.Json.Serialization;

namespace Integracao.Models
{
    public class MainWeatherData
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }
    }
}