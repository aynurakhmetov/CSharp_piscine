using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace d02._1
{
    class Configuration
    {
        public Hashtable Params { get; private set; }
        public List<IConfigurationSource> ConfigurationSource { get; private set; }

        public Configuration(List<IConfigurationSource> configSource)
        {
            this.ConfigurationSource = configSource;
            var selectedConfig = ConfigurationSource.OrderByDescending(t => t.Priority);
            foreach (var config in selectedConfig)
            {
                foreach (DictionaryEntry param in config.Params)
                {
                    if (!Params.ContainsKey(param.Key))
                        Params.Add(param.Key, param.Value);
                }
            }
        }
        public void Display()
        {
            Console.WriteLine("Configuration");
            foreach (DictionaryEntry param in Params)
            {
                Console.WriteLine($"{param.Key}: {param.Value}");
            }
        }
        
    }
}
