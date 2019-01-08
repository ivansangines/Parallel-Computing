using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example5
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
            Func<object, double> fptr = new Func<object, double>(mc.Compute);
            Task<double> tCompute = new Task<double>(fptr, 23.66f);
            // second parameter is the state object to pass
            tCompute.Start();
            MessageBox.Show(tCompute.Result.ToString());  // blocking call

            // you can  instead create a lambda that takes no parameter and 
            // calls your function
            Task<double> tCompute2 = new Task<double>(() => mc.Compute(45.57f));
            // <double> in above line indicates that the return value from 
            // Task is double
            tCompute2.Start();
            double res = tCompute2.Result;
            MessageBox.Show("Result = " + res.ToString());

        }
    }
}
