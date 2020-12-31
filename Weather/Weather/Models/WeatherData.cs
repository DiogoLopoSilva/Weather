using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Models
{
    public class WeatherData
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Timezone { get; set; }

        [JsonProperty("timezone_offset")]
        public int TimezoneOffset { get; set; }
        public Current Current { get; set; }
        public List<Daily> Daily { get; set; }
    }
}
