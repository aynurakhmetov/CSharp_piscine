using System;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace d03.Nasa.Lib
{
    public class AsteroidRequest
    {
        [JsonPropertyName("StartDate")]
        public string StartDate { get; set; }
        [JsonPropertyName("EndDate")]
        public string EndDate { get; set; }
        public int ResultCount { get; set; }
    }
}
