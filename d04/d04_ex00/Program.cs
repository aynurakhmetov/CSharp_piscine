using System;
using System.Reflection;
using Microsoft.AspNetCore.Http;


namespace d04_ex00
{
    class Program
    {
        static void Main(string[] args)
        {
            Type defaultHttpContextType = typeof(DefaultHttpContext);

            Console.WriteLine($"Type: {defaultHttpContextType.ToString()}");
            Console.WriteLine($"Assembly: {defaultHttpContextType.Assembly.FullName.ToString()}");
            Console.WriteLine($"Based on: {defaultHttpContextType.BaseType.ToString()}");
            Console.WriteLine();
            
            Console.WriteLine("Fields:");
            foreach (var fields in defaultHttpContextType.GetFields(BindingFlags.Public | 
                                   BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
            {
                Console.WriteLine($"{fields.FieldType} {fields.Name}");
            }
            Console.WriteLine();
            
            Console.WriteLine("Properties:");
            foreach (var properties in defaultHttpContextType.GetProperties(BindingFlags.Public | 
                                                                       BindingFlags.Instance | BindingFlags.Static))
            {
                Console.WriteLine($"{properties.PropertyType} {properties.Name}");
            }
            Console.WriteLine();
            
            Console.WriteLine("Methods:");
            foreach (var methods in defaultHttpContextType.GetMethods(BindingFlags.Public | 
                                                                      BindingFlags.Instance | BindingFlags.Static))
            {
                Console.Write($"{methods.ReturnType.Name} {methods.Name} (");

                ParameterInfo[] parameters = methods.GetParameters();
                for(int i = 0; i < parameters.Length; i++)
                {
                    Console.Write($"{parameters[i].ParameterType.Name} {parameters[i].Name}");
                    if(i + 1 < parameters.Length)
                    {
                        Console.Write(", ");
                    }
                }
                Console.WriteLine(")");  
            }
            Console.WriteLine();
        }
    }
}
