using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace spp_lab7
{
    class Program
    {
        static object locker = new object();
        static void method1()
        {
            Console.WriteLine("Задача 1");
            Thread.Sleep(200);
        }

        static void method2()
        {
            Console.WriteLine("Задача 2");
            Thread.Sleep(200);
        }

        static void method3()
        {
            Console.WriteLine("Задача 3");
            Thread.Sleep(200);
        }

        static void Main(string[] args)
        {
            TaskDelegate[] tasks = new TaskDelegate[] { method2, method1, method3,method2};
            Parallel.WaitAll(tasks);
            Console.WriteLine("---------");
            Console.WriteLine("действия основного потока после завершения потоков пула");
            Console.ReadKey();
        }
    }
}
