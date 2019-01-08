using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadPooling
{
    class SimpleWorker
    {
        public SimpleWorker(int data, ManualResetEvent ev)
        {
            inputData = data;
            mRE = ev;
        }
        object olock = new object();

        double result;
        public double Result
        {
            get { lock (olock) { return result; } }
        }
        ManualResetEvent mRE = null;
        int inputData = 0;
        public void MainCompute(object context)
        {
            // Writing to a Console does not
            // cause a cross threading error.
            // However, you can only see the Console
            // output if you choose Debug->Start debugging
            // Use Console.WriteLine for debugging
            // purposes
            if (context is DateTime)
            {
                Console.WriteLine(((DateTime)context).ToString());
            }
            double res = InternalCompute();
            Thread.Sleep(5000); // pretend it takes 5 secs to compute
            lock (olock) { result = res; }
            mRE.Set(); // signal the caller that thread is done
        }
        double InternalCompute()
        {
            return 45.7575 - inputData / 3.097 + 45.97;
        }
    }

}

