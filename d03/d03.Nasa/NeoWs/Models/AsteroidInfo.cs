using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace d03.Nasa.Lib
{
    class AsteroidInfo
    {
        [JsonPropertyName("near_earth_objects")]
        public NearEarthObjects near_earth_objects { get; set; }
    }
    
    public class NearEarthObjects
    {
       
        [JsonProperty("2015-09-07")]
        public List<_20150907> _20150907 { get; set; }
    }
    
    public class 20150907
    {
        public int id { get; set; }
        public List<CloseApproachData> close_approach_data { get; set; }
    }
        
    public class CloseApproachData
    {
        public MissDistance miss_distance { get; set; }
    }
    
    public class MissDistance
    {
        public string astronomical { get; set; }
        public string lunar { get; set; }
        public string kilometers { get; set; }
        public string miles { get; set; }
    }
}
