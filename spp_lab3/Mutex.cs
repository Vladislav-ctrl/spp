using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace spp_lab3
{
    class Mutex
    {
        private int counter = 0;
        public Mutex()
        {

        }

        public void Lock()
        {
            while (Interlocked.CompareExchange(ref counter, Thread.CurrentThread.ManagedThreadId, 0) != 0)
            {

            }
            /*
             Interlocked.CompareExchange(ref counter, Thread.CurrentThread.ManagedThreadId, 0);
            Console.WriteLine(counter);
            */
        }

        public void Unlock()
        { 
            if(Thread.CurrentThread.ManagedThreadId==counter)Interlocked.Exchange(ref counter, 0);
        }

    }
}
