using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example9
{
    public partial class Form1 : Form
    {

        bool bTerminate = false;
        Thread thShowTime = null;
        DelShowTime delShowTime = null;
        delegate void DelShowTime(string msg);

        public Form1()
        {
            InitializeComponent();
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            bTerminate = false;
            if (thShowTime == null)
                thShowTime = new Thread(new ThreadStart(this.ShowTime));

            if (thShowTime.ThreadState == ThreadState.Stopped)
                thShowTime = new Thread(new ThreadStart(this.ShowTime));
            thShowTime.Start();

        }

        void ShowTime()
        {
            while (bTerminate == false)
            {
                if (statusStrip1.InvokeRequired)
                {
                    if (bTerminate == false)
                        statusStrip1.Invoke(delShowTime, new string[] { DateTime.Now.ToLongTimeString() });
                }
                Thread.Sleep(1000);
            }
        }

        void UpdateTime(string msg)
        {
            lblStatus.Text = msg;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            delShowTime = new DelShowTime(this.UpdateTime);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            bTerminate = true;
            if (thShowTime != null)
            {
                if (thShowTime.ThreadState == ThreadState.Running)
                    thShowTime.Join();
            }
            lblStatus.Text = "stopped.. ";

        }
    }
}
