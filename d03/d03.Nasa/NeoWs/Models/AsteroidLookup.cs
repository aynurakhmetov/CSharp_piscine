using System.Text.Json.Serialization;

namespace d03.Nasa.Lib
{
    public class OrbitClass
    {
        [JsonPropertyName("orbit_class_type")]
        public string OrbitClassType { get; set; }
        [JsonPropertyName("orbit_class_description")]
        public string OrbitClassDescription { get; set; }
    }

    public class OrbitalData
    {
        [JsonPropertyName("orbit_class")]
        public OrbitClass OrbitClass { get; set; }
    }
    
    public class AsteroidLookup
    {
        [JsonPropertyName("neo_reference_id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("nasa_jpl_url")]
        public string NasaUrl { get; set; }
        [JsonPropertyName("is_potentially_hazardous_asteroid")]
        public bool IsPotentiallyHazardousAsteroid { get; set; }
        [JsonPropertyName("orbital_data")]
        public OrbitalData OrbitalData { get; set; }
    }
}
