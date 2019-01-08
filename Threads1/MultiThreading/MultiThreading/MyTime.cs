using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    class MyTime
    {
        int hours = 3;
        int mins = 59;
        int secs = 59;
        // any reference type can be used as a lock
        object olock = new object();
        public void IncrementTime()
        {
            lock (olock)
            {
                secs = secs + 1;
                if (secs == 60)
                {
                    secs = 0;
                    mins = mins + 1;
                    if (mins == 60)
                    {
                        mins = 0;
                        Thread.Sleep(100); // preempt
                        hours = hours + 1;
                    }
               }
            }     
        }
        public void ReadTime()
        {
            lock (olock)
            {
                Console.WriteLine(hours.ToString() +
                ":" + mins.ToString() +
                ":" + secs.ToString());
            }
        }
    }
}
