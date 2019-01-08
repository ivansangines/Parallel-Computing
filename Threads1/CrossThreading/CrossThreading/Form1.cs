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

namespace CrossThreading
{
    delegate void UpdateDel(string msg);

    public partial class Form1 : Form
    {
        Thread thClock = null;
        UpdateDel udel;
        bool terminate = false;

        public Form1()
        {
            InitializeComponent();
            udel = new UpdateDel(UpdateLabel);
        }

        private void btnClock_Click(object sender, EventArgs e)
        {
            thClock = new Thread(new ThreadStart(MyClock));
            thClock.Start();
        }

        void MyClock()
        {
            for (int i = 0; i < 10; i++)
            {
                // lblTime.Text = DateTime.Now.ToString();
                // we cannot update the label because
                // that will cause cross threading
                // error, use invoke on the UI element
                if (terminate == false)
                    lblTime.Invoke(udel, new string[] { DateTime.Now.ToString() });
                Thread.Sleep(1000);
            }
        }

        void UpdateLabel(string msg)
        {
            lblTime.Text = msg;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            terminate = true;
            if (thClock != null)
            {
                if (thClock.IsAlive)
                    thClock.Join();
            }
        }
    }

}
