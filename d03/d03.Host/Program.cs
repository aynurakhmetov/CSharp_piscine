using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using d03.Nasa;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace d03.Host
{
    class Program
    {
        static bool CheckStringForPositiveNumber(string stringForCheck, out int stringToInt)
        {
            if (int.TryParse(stringForCheck, out stringToInt) && stringToInt > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
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
                Console.WriteLine($"{media[i].Explanation}");
                Console.WriteLine($"{media[i].Url}");
                Console.WriteLine();
            }
        }

        static void DisplayAsteroid(AsteroidLookup[] asteroid)
        {
            for (int i = 0; i < asteroid.Length; i++)
            {
                Console.WriteLine($"- Asteroid {asteroid[i].Name}, SPK-ID: {asteroid[i].Id}");
                Console.Write($"IS POTENTIALLY HAZARDOUS!");
                Console.WriteLine($"Classification: {asteroid[i].OrbitalData.OrbitClass.OrbitClassType}," + 
                                  $"{asteroid[i].OrbitalData.OrbitClass.OrbitClassDescription}.");
                Console.WriteLine($"Url: {asteroid[i].NasaUrl}.");
                Console.WriteLine();
            }
        }
        
        static async Task<bool> StartApodAsync(string apiKey, int resultCount)
        {
            var apodClient = new ApodClient(apiKey);
            var mediaOfToday = await apodClient.GetAsync(resultCount);
            if (mediaOfToday != null)
            {
                DisplayMedia(mediaOfToday);
                return false;
            }
            return true;
        }

        static async Task<bool> StartNeoWsAsync(string apiKey, int resultCount, string[] args, AsteroidRequest asteroidRequest)
        {
            if (args.Length == 2)
            {
                asteroidRequest.ResultCount = resultCount;
            }
            else if (args.Length == 1)
            {
                asteroidRequest.ResultCount = -1;
            }
            var neoWsClient = new NeoWsClient(apiKey);
            var asteroid = await neoWsClient.GetAsync(asteroidRequest);
            if (asteroid != null)
            {
                DisplayAsteroid(asteroid);
                return false;
            }
            return true;
        }
        
        static async Task Main(string[] args)
        {
            const int oneArgFromConsole = 1;
            const int twoArgFromConsole = 2;

            const string configFile = "appsettings.json";
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(configFile);
            var configuration = builder.Build();
            
            var apiKey = configuration["ApiKey"];
            var asteroidRequest = new AsteroidRequest();
            asteroidRequest.StartDate = configuration["NeoWs:StartDate"];
            asteroidRequest.EndDate = configuration["NeoWs:EndDate"];

            int resultCount = 0;
            //apiKey = "";
            if (args.Length == twoArgFromConsole && args[0] == "apod" && CheckStringForPositiveNumber(args[1], out resultCount))
            {
                await StartApodAsync(apiKey, resultCount);
            }
            else if ((args.Length == oneArgFromConsole || args.Length == twoArgFromConsole &&
                         CheckStringForPositiveNumber(args[1], out resultCount)) && args[0] == "neows")
            {
                await StartNeoWsAsync(apiKey, resultCount, args, asteroidRequest);
            }
            else
            {
                Console.WriteLine("Incorrect input arguments");
                return;
            }
        }
    }
} 
