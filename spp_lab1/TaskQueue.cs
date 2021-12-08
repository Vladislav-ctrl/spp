using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace spp_lab1
{
    public class TaskQueue
    {
        public delegate void TaskDelegate();
        Queue<TaskDelegate> queue= new Queue<TaskDelegate>();
        static object locker = new object();
        public TaskQueue(int count)
        {
            for(int i=0; i < count; i++)
            {
                Thread thread = new Thread(task);
                thread.Start();
            }
        }

        public void task()
        {
            while (true)
            {
                TaskDelegate newTask=null;
                lock (locker)
                {
                    if (queue.Count != 0)
                    {
                        newTask = queue.Dequeue();
                    }
                }
                if(newTask!=null)newTask();
            }
        }

        public void EnqueueTask(TaskDelegate task)
        {
            queue.Enqueue(task);
        }
    }
}
