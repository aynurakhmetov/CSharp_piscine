using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

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
            
            
        }
    }
}
