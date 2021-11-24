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

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://api.nasa.gov/planetary/apod?api_key=" + apiKey);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine(responseBody);
            }
            Console.WriteLine(response.StatusCode);


            

        }
    }
} 
