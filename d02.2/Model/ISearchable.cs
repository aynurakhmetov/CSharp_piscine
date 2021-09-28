using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace d02._2
{
    public interface ISearchable
    {
        public string Title { get; set; }
        public string Type { get; set; }
    }
    
    public static class Enumerable
    {
        public static T[] Search<T>(this IEnumerable<T> list, string search)
            where T : ISearchable
        {
            var selected = list.Where(t => t.Title.ToLower().Contains(search.ToLower())).OrderBy(t => t.Title);
            var returnSelected = selected.ToArray();
            // foreach (var i in returnSelected)
            // {
            //     Console.WriteLine($"Title = {i.Title}");
            // }
            return returnSelected;
        }
    }
    
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("/media/gmarva/0EFE121D0EFE121D/Programming/Ecole42/CSharp_piscine/d02.2/appsettings.json");
             
            AppConfiguration = builder.Build();
        }
        // свойство, которое будет хранить конфигурацию
        public IConfiguration AppConfiguration { get; set; }
        
    }
}
