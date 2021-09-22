using System;
using System.Collections;
using System.Text.Json;
using System.IO;

namespace d02._1
{
    class EnvSource : IConfigurationSource
    {
        public string Path { get; set; }
        public string Priority { get; set; }
        public Hashtable Params { get; set; }
        private IDictionary ParamsDictionary { get; set; }
        public EnvSource()
        {
            this.Path = null;
            this.Priority = null;
            ParamsDictionary = System.Environment.GetEnvironmentVariables();
        }
        public void Deserialize()
        {
            try
            {
                Params = (Hashtable)ParamsDictionary;
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