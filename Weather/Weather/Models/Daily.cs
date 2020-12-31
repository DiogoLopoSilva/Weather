using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Models
{
    public class Daily : WeatherInfo
    {
        public Temp Temp { get; set; }

        [JsonProperty("feels_like")]
        public FeelsLike FeelsLike { get; set; }

        public double Pop { get; set; }
        public double Rain { get; set; }
        public string City { get; set; }
    }
}
