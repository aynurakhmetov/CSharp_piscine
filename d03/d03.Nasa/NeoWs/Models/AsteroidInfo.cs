using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace d03.Nasa.Lib
{
    public class AstInfo
    {
        [JsonPropertyName("near_earth_objects")]
        public NearEarthObjects NearEarthObjects { get; set; }
    }
    
    public class NearEarthObjects
    {
        //[JsonPropertyName("2015-09-07")]
        public Dictionary <String, AsteroidInfo> AsteroidInfoDic;
        
        // [JsonPropertyName()]
        // public List<AsteroidInfo> AsteroidInfoList { get; set; }
    }
    
    public class AsteroidInfo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
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
