using System;
using System.Threading;
using System.IO;


namespace spp_lab2
{
    class Program
    {
        static void copy(string file_path,string path_copy_to)
        {
            FileInfo fileInfo = new FileInfo(file_path);
            fileInfo.CopyTo(path_copy_to);
            Thread.Sleep(200);
        }

        static void Main(string[] args)
        {
            string path_from=null;
            bool check = true;
            while (check) { 
                Console.WriteLine("введите путь к исходному каталогу");
                path_from = Console.ReadLine();
                if (Directory.Exists(path_from))
                {
                    check = false;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }
            check = true;
            string path_to = null;
            while (check)
            {
                Console.WriteLine("введите путь к целевому каталогу");
                path_to = Console.ReadLine();
                if (Directory.Exists(path_to))
                {
                    check = false;
                }
                else {
                    Console.WriteLine("Некорректный ввод");
                }
            }
            string[] files = Directory.GetFiles(path_from);
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine(files[i]);
            }
            Console.WriteLine("from:" + path_from + "  to:" + path_to);
            //Console.WriteLine(Directory.Exists(path_from));
            //Console.ReadKey();
            
            
            TaskQueue taskQueue = new TaskQueue(3,path_to);
            for (int i = 0; i < files.Length; i++)
            {
                taskQueue.EnqueueFile(files[i]);
            }            
        }
    }
}

