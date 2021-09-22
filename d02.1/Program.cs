using System;
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
jsonSource.Deserialize();
yamlSource.Deserialize();

var configSource = new List<IConfigurationSource>();

if (jsonSource.Params != null)
{
    configSource.Add(jsonSource);
}
if (yamlSource.Params != null)
{
    configSource.Add(yamlSource);
}

if (configSource.Count != 0)
{
    var config = new Configuration(configSource);
    config.Display();
}
else
{
    return;
}

var envSource = new EnvSource();
envSource.Deserialize();
if (envSource.Params != null)
{
    configSource.Add(envSource);
}


if (configSource.Count != 0)
{
    var config = new Configuration(configSource);
    config.Display();
}
else
{
    return;
}

// dotnet run "config.json" 1 "config.yml" 2
// dotnet run "config.json" 1 "config.yml" 0