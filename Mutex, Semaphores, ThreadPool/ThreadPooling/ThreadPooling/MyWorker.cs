using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadPooling
{
    class MyWorker
    {
        ManualResetEvent mrev;
        object olock = new object();
        int workerNum = -1;
        public int WorkerNum
        {
            get { lock (olock) { return workerNum; } }
        }
        int inputData = -1;
        double result = 0;
        public double Result
        {
            get { lock (olock) { return result; } }
        }
        public MyWorker(ManualResetEvent ev, int inpData)
        {
            mrev = ev;
            inputData = inpData;
        }
        // main thread function
        public void ThreadPoolCallback(object context)
        {
            lock (olock) { workerNum = (int)context; }
            double res = DoWork(inputData);
            lock (olock) { result = res; }
            mrev.Set();
        }
        public double DoWork(int data)
        {
            Thread.Sleep(2000);
            return 5.2 * 3.8 - 25 + data;
        }
    }
}
