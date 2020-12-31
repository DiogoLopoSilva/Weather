using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Models
{
    public class Current : WeatherInfo
    {
        public double Temp { get; set; }

        [JsonProperty("feels_like")]
        public double FeelsLike { get; set; }
    }
}
