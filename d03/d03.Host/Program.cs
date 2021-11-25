using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace d03.Host
{
    class Program
    {
        static async Task Main(string[] args)
        {   
            // Reading the configuration
            const string configFile = "appsettings.json";
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(configFile);
            var configuration = builder.Build();
            var apiKey = configuration["ApiKey"];
            Console.WriteLine(apiKey);

            // Get command from command line as arguments
            if (args.Length == 2 && args[0] == "apod" && Int32.Parse(args[1]) > 0)
            {
                
            }
            else
            {
                Console.WriteLine("Incorrect input arguments");
                return;
            }

        }
    }
} 
