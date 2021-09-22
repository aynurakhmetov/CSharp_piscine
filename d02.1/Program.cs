using System;
using System.Collections;
using System.Collections.Generic;
using d02._1;

if (args.Length != 4)
{
    Console.WriteLine("Invalid data. Check your input and try again.");
    return;
}

//Console.WriteLine($"0 = {args[0]}, 1 = {args[1]}");
var jsonSource = new JsonSource(args[0], args[1]);
var yamlSource = new YamlSource(args[2], args[3]);
var configSource = new List<IConfigurationSource>();
configSource.Add(jsonSource);
configSource.Add(yamlSource);

var config = new Configuration(configSource);
