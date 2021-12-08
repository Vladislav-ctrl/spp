using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace spp_lab7
{
    class TaskQueue
    {
        Queue<TaskDelegate> queue = new Queue<TaskDelegate>();
        Thread[] list;
        static object locker = new object();
        public TaskQueue(int count)
        {
            list = new Thread[count];
            for (int i = 0; i < count; i++)
            {
                Thread thread = new Thread(task);
                //list.AddLast(thread);
                list[i] = thread;
                thread.Start();
            }
        }

        public void task()
        {
            while (true)
            {
                TaskDelegate newTask = null;
                lock (locker)
                {
                    if (queue.Count != 0)
                    {
                        newTask = queue.Dequeue();
                    }
                    else break;
                }
                if (newTask != null) newTask();
            }
        }

        public void EnqueueTask(TaskDelegate task)
        {
            queue.Enqueue(task);
        }

        public Thread[] getThreads()
        {
            return list;
        }
    }
}

