using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Threading2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.HoursWorked = Convert.ToInt32(textBox1.Text);
            emp.PayRate = Convert.ToDouble(textBox2.Text);
            label3.Text = "The Employee salary is $ " + emp.ComputePay();

        }
    }
}
