using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MyCompute mc = new MyCompute();
            Func<float, float, double> fptr = new Func<float, float, double>(mc.Compute2);
            // also OK, We would be using Func deligate:
            // var task = new Task<double>(() => fptr(23.67f,12.66f));  

            var task = new Task<double>(() => mc.Compute2(23.67f, 12.66f));
            task.Start();
            task.Wait();  // wait for task to complete
            MessageBox.Show(task.Result.ToString());



        }
    }
}
