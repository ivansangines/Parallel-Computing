using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MutexTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMutexTest_Click(object sender, EventArgs e)
        {
            bool reqCreation = true; // to request creation of a mutex
            bool alreadyExists; // if a mutex already exists
            int thId = System.AppDomain.GetCurrentThreadId();
            Mutex m1 = new Mutex(reqCreation, "MyMutex", out alreadyExists);
            // check to see if the mutex is owned by this thread
            if (!(reqCreation && alreadyExists))
            {
                sb1.Text = "Mutex already exists, waiting on its release..." +
                thId.ToString();
                m1.WaitOne(); // this thread wil block here
            }
            sb1.Text = "Starting to use the resource, .. mutex owner" +
            thId.ToString();
            // if this is the owner thread, you can use the shared resource
            Thread.Sleep(10000);
            // done using the resource
            sb1.Text = "Done using mutex, releasing resource ..." + thId.ToString();
            m1.ReleaseMutex();
        }
    }
}
