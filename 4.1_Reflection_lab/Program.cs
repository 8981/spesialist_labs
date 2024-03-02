using System.Reflection;

namespace _4._1_Reflection_lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly lib = Assembly.LoadFrom("4.1_ReflectionLib_lab.dll");
            Type[] types = lib.GetTypes();


            foreach (Type t in types)
            {
                TypeInfo typeInfo = t.GetTypeInfo();
                var classModifire = typeInfo.Attributes;
                
                if (t.IsClass)
                {
                    Console.WriteLine($"{t.Name}: class modifire {classModifire}");
                    PropertyInfo[] properties = t.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

                    foreach (PropertyInfo prop in properties)
                    {
                        var modifiers = prop.GetAccessors()[0].Attributes;
                        Console.WriteLine($"  Property: {prop.Name}, Modifiers: {modifiers}");
                    }
                }
            }
        }
    }
}
