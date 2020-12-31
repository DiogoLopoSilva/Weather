using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Models
{
    public class Current
    {
        public int Dt { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
        public double Temp { get; set; }

        [JsonProperty("feels_like")]
        public double FeelsLike { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }

        [JsonProperty("dew_point")]
        public double DewPoint { get; set; }
        public double Uvi { get; set; }
        public int Clouds { get; set; }
        public int Visibility { get; set; }

        [JsonProperty("wind_speed")]
        public double WindSpeed { get; set; }

        [JsonProperty("wind_deg")]

        public int WindDeg { get; set; }
        public List<Weather> Weather { get; set; }
    }
}
