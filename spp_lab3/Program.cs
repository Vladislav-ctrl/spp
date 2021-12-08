using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading; 

namespace spp_lab3
{
    class Program
    {
        static void method1()
        {
            Console.WriteLine("задача 1     " + Thread.CurrentThread.ManagedThreadId );
            Thread.Sleep(2);
        }

        static void method2()
        {
            Console.WriteLine("задача 2     " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2);
        }

        static void method3()
        {
            Console.WriteLine("задача 3     "+Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2);
        }

        static void Main(string[] args)
        {
            TaskQueue taskQueue = new TaskQueue(3);
            taskQueue.EnqueueTask(method2);
            taskQueue.EnqueueTask(method3);
            taskQueue.EnqueueTask(method1);
            taskQueue.EnqueueTask(method2);
            Console.ReadKey();
        }
    }
}
