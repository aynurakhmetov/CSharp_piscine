using System;
using System.Reflection;
using Microsoft.AspNetCore.Http;

namespace d04_ex01
{
    class Program
    {
        static void Main(string[] args)
        {
            var defaultHttpContext = new DefaultHttpContext();
            Console.WriteLine($"Old Response value: {defaultHttpContext.Response.ToString()}");
            
            var typeDefaultHttpContext = typeof(DefaultHttpContext);
            var responseFieldInfo = typeDefaultHttpContext.GetField("_response",
                BindingFlags.NonPublic | BindingFlags.Instance);
            //Console.WriteLine($"Old Response value: {myFieldInfo.GetValue(defaultHttpContext)}");

            responseFieldInfo.SetValue(defaultHttpContext, null);
            Console.WriteLine($"New Response value: {responseFieldInfo.GetValue(defaultHttpContext)}");
        }
    }
}
