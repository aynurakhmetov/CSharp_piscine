using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace d04_ex02
{
    public class ConsoleSetter
    {
        public ConsoleSetter()
        {
        }
        
        public void SetValues<T>(T input) where T: class
        {
            bool isNoDisplayAttribute = false;
            
            var typeName = typeof(T);
            Console.WriteLine($"Let's set {typeName.Name}!");
            
            foreach (var property in typeName.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                System.Attribute[] attrs = System.Attribute.GetCustomAttributes(property);
                foreach (System.Attribute attr in attrs)
                {
                    if (attr is NoDisplayAttribute)
                    {
                        isNoDisplayAttribute = true;
                    }
                }
                if (isNoDisplayAttribute == false)
                {
                    AttributeCollection attributes = TypeDescriptor.GetProperties(input)[property.Name].Attributes;
                    DescriptionAttribute myAttribute = (DescriptionAttribute)attributes[typeof(DescriptionAttribute)];
                    if (myAttribute.Description != "")
                        Console.WriteLine($"Set {myAttribute.Description}:");
                    else
                    {
                        Console.WriteLine($"Set {property.Name}:");
                    }
                    var value = Console.ReadLine();
                    if (value == "")
                    {
                        DefaultValueAttribute myAttribute2 = (DefaultValueAttribute)attributes[typeof(DefaultValueAttribute)];
                        property.SetValue(input, myAttribute2.Value);
                    }
                    else
                    {
                        property.SetValue(input, value);
                    }
                }
                isNoDisplayAttribute = false;
            }
            Console.WriteLine();
            Console.WriteLine("We've set our instance!");
            Console.WriteLine($"{input.ToString()}");
        }
    }
}
