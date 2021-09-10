using System.Collections;

namespace d02_ex01
{
    interface IConfigurationSource
    {
        public string Path { get; set; }
        public string Priority { get; set;}
        public Hashtable Params { get; set; }
        public void Deserialize();
    }
}