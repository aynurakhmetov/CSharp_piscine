using System;
using System.Collections;
using System.IO;
using YamlDotNet.Serialization;

namespace d02_ex01
{
    class YamlSource : IConfigurationSource
    {
        public string Path { get; set; }
        public string Priority { get; set; }
        public Hashtable Params { get; set; }
        
        public YamlSource(string path, string priotity)
        {
            this.Path = path;
            this.Priority = priotity;
        }

        public void Deserialize()
        {
            try
            {
                string yamlFileString = File.ReadAllText(Path);
                var deserializer = new DeserializerBuilder().Build();
                Params = deserializer.Deserialize<Hashtable>(yamlFileString);
                // foreach(DictionaryEntry param in Params)
                //     Console.WriteLine("Key: {0}, Value: {1}", param.Key, param.Value);
            }
            catch
            {
                Console.WriteLine("Invalid data. Check your input and try again.");
            }
        }
    }
}
