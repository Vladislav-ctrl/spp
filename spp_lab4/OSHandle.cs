using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace spp_lab4
{
    class OSHandle:IDisposable
    {
        [DllImport("kernel32.dll")] private static extern bool CloseHandle(IntPtr handle);
        public IntPtr Handle { get; set; }

        private bool disposed = false;

        public OSHandle(IntPtr handle)
        {
            this.Handle = handle;
        }

        ~OSHandle(){
            Dispose(false);
        }

        /*
        protected override void Finalize()
        {

        }
        */
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {

                }
                if (CloseHandle(Handle))
                {
                    Console.WriteLine("Handle " + Handle + " was disposed");
                    Handle=IntPtr.Zero;
                }
                disposed=true;       
            }
        }

    }
}
