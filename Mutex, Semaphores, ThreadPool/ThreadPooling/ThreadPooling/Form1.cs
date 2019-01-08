using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace ThreadPooling
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnThreadPool_Click(object sender, EventArgs e)
        {
            ManualResetEvent mr = new ManualResetEvent(false);
            // gate is closed
            SimpleWorker sw = new SimpleWorker(25, mr);
            WaitCallback wcb = new WaitCallback(sw.MainCompute);
            // wcb is pointing to MainCompute
            // create a launch ThreadPool thread
            int maxWorkerThreads = 0;
            int maxCompletionPorts = 0;
            ThreadPool.GetMaxThreads(out maxWorkerThreads, out maxCompletionPorts);
            MessageBox.Show(maxWorkerThreads.ToString());
            ThreadPool.QueueUserWorkItem(wcb, DateTime.Now);
            // no start method in threadpool, above line
            // starts the thread
            mr.WaitOne(); // wait for thread to finish

            MessageBox.Show("Result = " +sw.Result.ToString());
        }

        private void btnThreadPoolArray_Click(object sender, EventArgs e)
        {
            MyWorker[] workers = new MyWorker[10];
            ManualResetEvent[] ev = new ManualResetEvent[10];
            for (int i = 0; i < 10; i++)
            {
                ev[i] = new ManualResetEvent(false);
                workers[i] = new MyWorker(ev[i], i);

                ThreadPool.QueueUserWorkItem(workers[i].ThreadPoolCallback, i);
            }
            WaitHandle.WaitAll(ev); //WaitHandle.WaitAll(ev);
            MessageBox.Show("All threads done..");
            string out1 = "";
            for (int i = 0; i < 10; i++)
            {
                out1 += workers[i].WorkerNum.ToString() + " "
                + workers[i].Result.ToString() + "\n";
            }
            MessageBox.Show(out1);
        }
    }
}
