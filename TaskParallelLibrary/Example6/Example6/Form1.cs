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

namespace Example6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Task t1 = Task.Factory.StartNew(() => { Thread.Sleep(3000); MessageBox.Show("Done with Task"); });

            // Getting a result from a task that is created via StartNew
            Task<double> t2 = Task.Factory.StartNew<double>(() =>
            {
                double avg = 0;
                int[] data = { 25, 78, 32, 91, 88, 67, 45 };
                avg = data.Average();
                return avg;
            });
            double res = t2.Result;
            MessageBox.Show("Result = " + res.ToString());
            // this is output before t1 task because of Sleep call in t1

        }
    }
}
