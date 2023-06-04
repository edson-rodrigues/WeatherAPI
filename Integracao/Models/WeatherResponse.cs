using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Integracao.Models
{
    public class WeatherResponse
    {
        [JsonPropertyName("main")]

        public MainWeatherData Main { get; set; }
    }
}
