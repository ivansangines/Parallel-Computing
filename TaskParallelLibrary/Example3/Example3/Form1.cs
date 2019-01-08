using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Action<Object> act2 = new Action<Object>(
       (obj) => {
           MessageBox.Show("Task with Action<object> called at " +
          obj.ToString());
           //DateTime dt = (DateTime)obj;
           //MessageBox.Show(dt.Ticks.ToString());
       });
            Task t2 = new Task(act2, DateTime.Now);
            // second parameter is state
            t2.Start();
            MessageBox.Show(t2.AsyncState.ToString());
            // get the state object that
            // was specified with Task and Action<object>

        }
    }
}
