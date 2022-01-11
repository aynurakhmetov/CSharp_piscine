using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace d03.Nasa
{
    public class AstInfo
    {
        [JsonPropertyName("near_earth_objects")]
        public Dictionary <string, AsteroidInfo[]> AsteroidInfos { get; set; }
    }
    
    public class AsteroidInfo
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("close_approach_data")]
        public List<CloseApproachData> CloseApproachDataList { get; set; }
    }
        
    public class CloseApproachData
    {
        [JsonPropertyName("miss_distance")]
        public MissDistance MissDistance { get; set; }
    }
    
    public class MissDistance
    {
        [JsonPropertyName("kilometers")]
        public string Kilometers { get; set; }
    }
}
