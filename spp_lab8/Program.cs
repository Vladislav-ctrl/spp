using System;
using System.IO;
using System.Reflection;

namespace spp_lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = null;
            bool check = true;
            while (check)
            {
                Console.WriteLine("введите путь к сборке");
                path = Console.ReadLine();
                if (File.Exists(path))
                {
                    check = false;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }
            Assembly asm = Assembly.LoadFrom(path);
            Type[] types = asm.GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].IsPublic)
                {
                    object[] attributes = types[i].GetCustomAttributes(false);
                    for (int j = 0; j < attributes.Length; j++)
                    {
                        if (attributes[j].GetType().Name == "ExportClass")
                        {
                            Console.WriteLine(types[i].Name);
                            break;
                        }
                    }
                    //Console.WriteLine(types[i].FullName);
                }
            }
            Console.ReadKey();
        }
    }
}
