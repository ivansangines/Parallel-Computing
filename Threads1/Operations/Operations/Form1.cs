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

namespace Operations
{
    public partial class Form1 : Form
    {
        Thread thCompute = null;
        Thread thWeather = null;
        Thread thStock = null;
        LongOperations lop = null;

        public Form1()
        {
            InitializeComponent();
            //Form1_Load(this, null);
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //Form1_Load(this, null);
            lop.Data = 25;
            thCompute = new Thread(new ThreadStart(lop.Compute));
            thCompute.Start();
            thCompute.Join(); // wait for thread to finish
            double res = lop.Result;
            MessageBox.Show(res.ToString());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Form1_Load(this, null);
            MessageBox.Show(lop.Temperature.ToString());

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lop = new LongOperations();
            thWeather = new Thread(new ThreadStart(lop.GetWeather));
            // for long running threads that can be
            // stopped halfway without causing any
            // harm, set them as background threads
            // Background threads get terminated
            // automatically when the parent process
            // is terminated
            thWeather.IsBackground = true;
            thWeather.Start();
            thStock = new Thread(new ThreadStart(lop.GetStockPrice));
            thStock.Start();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            lop.Terminate = true;
            if (thStock != null)
            {
                if (thStock.IsAlive)
                {
                    thStock.Join(); // wait for thread to finish
                }
            }
            if (thCompute != null)
            {
                if (thCompute.IsAlive)
                    thCompute.Join();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Form1_Load(this, null);
            //Form1_FormClosing(this, null);
            MessageBox.Show(lop.StockPrice.ToString());
            

        }


    }
}
