using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using d03.Nasa.Lib;


using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace d03.Host
{
    class Program
    {
        static void DisplayMedia(MediaOfToday[] media)
        {
            for (int i = 0; i < media.Length; i++)
            {
                Console.WriteLine(media[i].Date.ToString("d"));
                Console.Write($"'{media[i].Title}'");
                if (media[i].Copyright != null)
                {
                    Console.WriteLine($" by {media[i].Copyright}");
                }
                else
                {
                    Console.WriteLine();
                }
                Console.WriteLine($"{media[i].Explanation}");
                Console.WriteLine($"{media[i].Url}");
                Console.WriteLine();
            }
        }
        
        static async Task Main(string[] args)
        {   
            // Reading the configuration
            const string configFile = "appsettings.json";
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(configFile);
            var configuration = builder.Build();
            var apiKey = configuration["ApiKey"];
            //Console.WriteLine(apiKey);

            // Get command from command line as arguments
            int resultCount;
            if (args.Length == 2 && args[0] == "apod" && int.TryParse(args[1], out resultCount) && resultCount > 0)
            {
                //apiKey = "";
                var apodClient = new ApodClient(apiKey);
                var mediaOfToday = await apodClient.GetAsync(resultCount);
                //Console.WriteLine($"AAA {mediaOfToday[0].Title}");
                if (mediaOfToday != null)
                    DisplayMedia(mediaOfToday);
                // вывод данных здесь надо реализовать
            }
            else
            {
                Console.WriteLine("Incorrect input arguments");
                return;
            }
            // ACviVFWbJxyNf7Yqp5wPj0R6B6FKRYKdPebV1GqA
            // как правильно давать названия коммитам
        }
    }
} 
