using d02_ex01;
using System;

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

var configuration = new Configuaration();

if (jsonSource.Params != null && yamlSource.Params != null)
{
    configuration.Add(jsonSource);
    configuration.Add(yamlSource);
    configuration.Display();
}


