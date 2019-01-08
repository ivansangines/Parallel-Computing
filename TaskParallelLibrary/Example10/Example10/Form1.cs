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

namespace Example10
{
    public partial class Form1 : Form
    {
        bool bTerminate = false;
        DelShowTime delShowTime = null;
        delegate void DelShowTime(string msg);
        Task tskShowTime = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            bTerminate = false;
            if (tskShowTime == null)
                tskShowTime = new Task(ShowTime);
            if (tskShowTime.IsCompleted)
                tskShowTime = new Task(ShowTime);
            tskShowTime.Start();

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


        private void btnStop_Click(object sender, EventArgs e)
        {
            bTerminate = true;
            if (tskShowTime != null)
            {
                if (tskShowTime.Status == TaskStatus.Running)
                    tskShowTime.Wait();
            }
            lblStatus.Text = "stopped.. ";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            delShowTime = new DelShowTime(this.UpdateTime);

        }
    }
}
