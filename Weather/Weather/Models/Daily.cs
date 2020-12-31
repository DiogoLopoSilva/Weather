using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Models
{
    public class Daily
    {
        public int Dt { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
        public Temp Temp { get; set; }

        [JsonProperty("feels_like")]
        public FeelsLike FeelsLike { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }

        [JsonProperty("dew_point")]
        public double DewPoint { get; set; }

        [JsonProperty("wind_speed")]
        public double WindSpeed { get; set; }

        [JsonProperty("wind_deg")]
        public int WindDeg { get; set; }
        public List<Weather> Weather { get; set; }
        public int Clouds { get; set; }
        public double Pop { get; set; }
        public double Rain { get; set; }
        public double Uvi { get; set; }
    }
}
