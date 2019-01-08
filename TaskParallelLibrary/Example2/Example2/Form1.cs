using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void DoAdd(int a, int b)
        {
            int sum = a + b;
            MessageBox.Show("sum = " + sum.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Action<int, int> actAdd = new Action<int, int>(this.DoAdd);
            Task t1a = new Task(() => actAdd(5, 7));
            t1a.Start();
            t1a.Wait(); //shows the result of the sum and not the form until task is done

            

        }
    }
}
