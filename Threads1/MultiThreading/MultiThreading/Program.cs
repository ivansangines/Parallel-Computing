using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTime mt = new MyTime();
            Thread th1 = new Thread(new ThreadStart(mt.IncrementTime));
            Thread th2 = new Thread(new ThreadStart(mt.ReadTime));
            th1.Start();
            Thread.Sleep(50);
            th2.Start();
        }
    }
}
