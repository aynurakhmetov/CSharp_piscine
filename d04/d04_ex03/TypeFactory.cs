
using System;
using System.Reflection;

namespace d04_ex03
{
    public class TypeFactory
    {
        public static T CreateWithConstructor<T>() where T : class
        {
            Type[] types = new Type[0];
            var typeOfT = typeof(T);

            ConstructorInfo constructorInfoObj = typeOfT.GetConstructor(
                BindingFlags.Instance | BindingFlags.Public, null,
                CallingConventions.HasThis, types, null);
            
            return (T)constructorInfoObj.Invoke(null);
        }

        public static T CreateWithActivator<T>() where T : class
        {
            Object instanceOfT = Activator.CreateInstance(typeof(T));

            return (T)instanceOfT;
        }

        public static T CreateWithParameters<T>(object[] objects) where T : class
        {
            Object instanceOfT = Activator.CreateInstance(typeof(T), objects);

            return (T)instanceOfT;
        }
    }
}
