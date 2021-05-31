using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectD.Models
{
    public class User
    {
        [JsonProperty("fullame")]
        public string Username { get; set; }
        [JsonProperty("age")]
        public int Age { get; set; }
    }
}
