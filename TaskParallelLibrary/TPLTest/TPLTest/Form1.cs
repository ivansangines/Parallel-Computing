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

namespace TPLTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnThreadLikeTask_Click(object sender, EventArgs e)
        {
            /*
            // MultiThreading code
            MyCompute mc = new MyCompute();
            mc.Data1 = 24.22f;
            mc.Data2 = 11;
            Action fCompute = new Action(mc.Compute3);
            Thread thCompute = new Thread(new ThreadStart(fCompute));
            thCompute.Start();
            thCompute.Join();
            MessageBox.Show("Result = " + mc.Res.ToString());
            */

            //Task Code
            MyCompute mc = new MyCompute();
            mc.Data1 = 24.22f;
            mc.Data2 = 11;
            Action fCompute = new Action(mc.Compute3);
            Task t1 = new Task(fCompute);
            t1.Start();
            t1.Wait();
            MessageBox.Show("Result = " + mc.Res.ToString());


        }
    }
}
