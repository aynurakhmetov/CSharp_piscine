using System;
using System.Collections;
using System.Text.Json;
using System.IO;

namespace d02_ex01
{
    class JsonSource : IConfigurationSource
    {
        public string Path { get; set; }
        public string Priority { get; set; }
        public Hashtable Params { get; set; }

        public JsonSource(string path, string priotity)
        {
            this.Path = path;
            this.Priority = priotity;
        }

        public void Deserialize()
        {
            try
            {
                string jsonFileString = File.ReadAllText(Path);
                Params = JsonSerializer.Deserialize<Hashtable>(jsonFileString);
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
