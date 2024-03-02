using System.Reflection;

namespace _4._1_Reflection_lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly lib = Assembly.LoadFrom("4.1_ReflectionLib_lab.dll");
            Type[] types = lib.GetTypes();

            foreach (Type type in types)
            {
                if (type.IsClass)
                {
                    Console.WriteLine(type.FullName);
                }
            }
        }
    }
}
