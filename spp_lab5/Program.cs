using System;
using System.IO;
using System.Reflection;

namespace spp_lab5
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
            //Console.WriteLine(asm.FullName);
            Type[] types = asm.GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].IsPublic)
                {
                    Console.WriteLine(types[i].FullName);
                }
            }
            Console.ReadKey();
        }
    }
}
