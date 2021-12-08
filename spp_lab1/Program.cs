using System;
using System.Threading;

namespace spp_lab1
{
    public class Program
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
            TaskQueue taskQueue = new TaskQueue(3);
            taskQueue.EnqueueTask(method2);
            taskQueue.EnqueueTask(method3);
            taskQueue.EnqueueTask(method1);
            taskQueue.EnqueueTask(method2);
        }
    }
}
