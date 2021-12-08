using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace spp_lab2
{
    class TaskQueue
    {
        public delegate void TaskDelegate(string file_path, string path_copy_to);
        Queue<string> file_queue = new Queue<string>();
        string path_copy_to;
        int count_of_files = 0;
        static object locker = new object();
        public TaskQueue(int count,string path_copy_to)
        {
            this.path_copy_to = path_copy_to;
            for (int i = 0; i < count; i++)
            {
                Thread thread = new Thread(task);
                thread.Start();
            }
        }

        public void task()
        {
            bool last = false;
            while (true)
            {
                string file = null;
                lock (locker)
                {
                    if (file_queue.Count != 0)
                    {
                        file = file_queue.Dequeue();
                        if (file_queue.Count == 0) last = true;
                    }
                }
                if (file != null)
                {
                    Console.WriteLine(Thread.CurrentThread.GetHashCode());
                    FileInfo fileInfo = new FileInfo(file);
                    fileInfo.CopyTo(path_copy_to+"//"+fileInfo.Name);
                    count_of_files++;
                    if (last) Console.WriteLine("Количесвто скопированных файлов:"+count_of_files);
                    Thread.Sleep(100);
                };
            }
        }

        public void EnqueueFile(string file)
        {
            file_queue.Enqueue(file);
        }
    }
}
