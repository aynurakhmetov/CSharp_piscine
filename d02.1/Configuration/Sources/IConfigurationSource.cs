using System;
using System.Collections;
using System.Collections.Generic;

namespace d02._1
{
    class IConfigurationSource
    {
        public string Path { get; set; }
        public string Priority { get; set;}
        public Hashtable Params { get; set; }
    }
}
