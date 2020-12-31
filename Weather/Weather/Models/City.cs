using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Models
{
    public class City
    {
        public Coord Coord { get; set; }

        public string Name { get; set; }
    }
}
