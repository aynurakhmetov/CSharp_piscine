using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace d02_ex01
{
    class Configuaration
    {
        public Hashtable Params { get; private set; }
        public List<IConfigurationSource> ConfigurationSource { get; private set; }

        public Configuaration()
        {
            this.Params = new Hashtable();
            this.ConfigurationSource = new List<IConfigurationSource>();
        }

        public void Add(IConfigurationSource configSource)
        {
            
            ConfigurationSource.Add(configSource);
        }

        public void Display()
        {
            var selectedConfig = ConfigurationSource.OrderByDescending(t => t.Priority);
            foreach (var config in selectedConfig)
            {
                foreach (DictionaryEntry param in config.Params)
                {
                    if (!Params.ContainsKey(param.Key))
                        Params.Add(param.Key, param.Value);
                }
            }
            Console.WriteLine("Configuration");
            foreach (DictionaryEntry param in Params)
            {
                Console.WriteLine($"{param.Key}: {param.Value}");
            }
        }
    }
}