using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace spp_lab4
{
    class Program
    {
        public const uint GENERIC_READ = 0x80000000;
        public const uint OPEN_EXISTING = 3;
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern SafeFileHandle CreateFile(string lpFileName, uint dwDesiredAccess,
        uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition,
        uint dwFlagsAndAttributes, IntPtr hTemplateFile);

        static void Main(string[] args)
        {

            SafeFileHandle file = CreateFile("D:/1/11.txt", GENERIC_READ, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);

            using(OSHandle oshandle = new OSHandle(file.DangerousGetHandle())) { 
                Console.WriteLine(oshandle.Handle);
            }

            GC.Collect();

            Console.ReadKey();
        }

        
    }
}
