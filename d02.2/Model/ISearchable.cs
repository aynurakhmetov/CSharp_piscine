using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

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
}
