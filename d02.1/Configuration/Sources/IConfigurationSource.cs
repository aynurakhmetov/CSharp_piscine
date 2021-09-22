using System;
using System.Collections;
using System.Collections.Generic;

namespace d02._1
{
    interface IConfigurationSource
    {
        public string Path { get; set; }
        public string Priority { get; set;}
        public Hashtable Params { get; set; }
        public void Deserialize();
    }
}
