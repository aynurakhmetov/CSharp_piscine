using System.Text.Json.Serialization;

namespace d03.Nasa.Lib
{
    public class MediaOfToday
    {
        [JsonPropertyName("copyright")]
        public string Copyright { get; set; }
        [JsonPropertyName("date")]
        public System.DateTime Date { get; set; }
        [JsonPropertyName("explanation")]
        public string Explanation { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}