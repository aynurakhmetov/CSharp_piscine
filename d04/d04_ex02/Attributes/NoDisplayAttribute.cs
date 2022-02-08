using System;

namespace d04_ex02
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class NoDisplayAttribute : System.Attribute
    {
    }
}
