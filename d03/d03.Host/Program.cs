using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace d03.Host
{
    class Program
    {
        static void Main(string[] args)
        {   
            // Reading the configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            
            string apiKey = configuration["ApiKey"];
            Console.WriteLine(apiKey);
            
            
        }
    }
}
