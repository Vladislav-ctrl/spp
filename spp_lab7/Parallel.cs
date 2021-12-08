using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace spp_lab7
{
    public  delegate void TaskDelegate();
    class Parallel
    {
        public static void WaitAll(TaskDelegate[] mas)
        {
            TaskQueue pool = new TaskQueue(3);
            for (int i = 0; i < mas.Length; i++)
            {
                pool.EnqueueTask(mas[i]);
            }
            Thread[] threads= pool.getThreads();
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }
        }
    }
}
