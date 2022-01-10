using System.Text.Json.Serialization;

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
