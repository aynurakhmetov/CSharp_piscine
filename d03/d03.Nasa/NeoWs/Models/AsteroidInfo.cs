using System;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace d03.Nasa.Lib
{
    class AsteroidInfo
    {
        
    }
    
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Links
    {
        public string next { get; set; }
        public string prev { get; set; }
        public string self { get; set; }
    }

    public class Kilometers
    {
        public double estimated_diameter_min { get; set; }
        public double estimated_diameter_max { get; set; }
    }

    public class Meters
    {
        public double estimated_diameter_min { get; set; }
        public double estimated_diameter_max { get; set; }
    }

    public class Miles
    {
        public double estimated_diameter_min { get; set; }
        public double estimated_diameter_max { get; set; }
    }

    public class Feet
    {
        public double estimated_diameter_min { get; set; }
        public double estimated_diameter_max { get; set; }
    }

    public class EstimatedDiameter
    {
        public Kilometers kilometers { get; set; }
        public Meters meters { get; set; }
        public Miles miles { get; set; }
        public Feet feet { get; set; }
    }

    public class RelativeVelocity
    {
        public string kilometers_per_second { get; set; }
        public string kilometers_per_hour { get; set; }
        public string miles_per_hour { get; set; }
    }

    public class MissDistance
    {
        public string astronomical { get; set; }
        public string lunar { get; set; }
        public string kilometers { get; set; }
        public string miles { get; set; }
    }

    public class CloseApproachData
    {
        public string close_approach_date { get; set; }
        public string close_approach_date_full { get; set; }
        public object epoch_date_close_approach { get; set; }
        public RelativeVelocity relative_velocity { get; set; }
        public MissDistance miss_distance { get; set; }
        public string orbiting_body { get; set; }
    }

    public class 20150908
    {
        public Links links { get; set; }
        public string id { get; set; }
        public string neo_reference_id { get; set; }
        public string name { get; set; }
        public string nasa_jpl_url { get; set; }
        public double absolute_magnitude_h { get; set; }
        public EstimatedDiameter estimated_diameter { get; set; }
        public bool is_potentially_hazardous_asteroid { get; set; }
        public List<CloseApproachData> close_approach_data { get; set; }
        public bool is_sentry_object { get; set; }
    }

    public class 20150907
    {
        public Links links { get; set; }
        public string id { get; set; }
        public string neo_reference_id { get; set; }
        public string name { get; set; }
        public string nasa_jpl_url { get; set; }
        public double absolute_magnitude_h { get; set; }
        public EstimatedDiameter estimated_diameter { get; set; }
        public bool is_potentially_hazardous_asteroid { get; set; }
        public List<CloseApproachData> close_approach_data { get; set; }
        public bool is_sentry_object { get; set; }
    }

    public class NearEarthObjects
    {
        [JsonProperty("2015-09-08")]
        public List<_20150908> _20150908 { get; set; }

        [JsonProperty("2015-09-07")]
        public List<_20150907> _20150907 { get; set; }
    }

    public class Root
    {
        public Links links { get; set; }
        public int element_count { get; set; }
        public NearEarthObjects near_earth_objects { get; set; }
    }


}
