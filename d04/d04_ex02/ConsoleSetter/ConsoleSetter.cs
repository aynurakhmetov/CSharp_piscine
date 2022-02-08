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
            var typeName = typeof(T);
            Console.WriteLine($"Let's set {typeName.Name}!");
            
            //bool isNoDisplayAttribute;
            
            foreach (var property in typeName.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                //isNoDisplayAttribute = this.CheckNoDisplayAttributeOnProperty(property);
                if (this.CheckNoDisplayAttributeOnProperty(property) == false)
                {
                    this.SetProperty(property, input);
                }
                //isNoDisplayAttribute = false;
            }
            
            Console.WriteLine();
            Console.WriteLine("We've set our instance!");
            Console.WriteLine($"{input.ToString()}");
        }
        
        private bool CheckNoDisplayAttributeOnProperty(PropertyInfo property)
        {
            Attribute[] attributes = Attribute.GetCustomAttributes(property);
            
            foreach (var attribute in attributes)
            {
                if (attribute is NoDisplayAttribute)
                {
                    return true;
                }
            }
            return false;
        }

        private void SetProperty<T>(PropertyInfo property, T input) where T: class
        {
            AttributeCollection attributes = TypeDescriptor.GetProperties(input)[property.Name].Attributes;
            DescriptionAttribute descriptionAttribute = (DescriptionAttribute)attributes[typeof(DescriptionAttribute)];

            if (descriptionAttribute.Description != "")
            {
                Console.WriteLine($"Set {descriptionAttribute.Description}:");
            }
            else
            {
                Console.WriteLine($"Set {property.Name}:");
            }
            
            var value = Console.ReadLine();
            
            if (value == "")
            {
                DefaultValueAttribute defaultAttribute = (DefaultValueAttribute)attributes[typeof(DefaultValueAttribute)];
                property.SetValue(input, defaultAttribute.Value);
            }
            else
            {
                property.SetValue(input, value);
            }
        }
    }
}
