using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //USING REGULAR EXPRESSIONS

            /*
            Action act = new Action(DoSomething);
            Task t = new Task(DoSomething);
            t.Start();

            void DoSomething()
            {
                // some task, e.g., update DB
                MessageBox.Show("Task done..");
            }
            */
                     
            //USING LAMBDA EXPRESSION

            Action act1 = new Action(() => MessageBox.Show("Task with Action."));
            Task t1 = new Task(act1);
            t1.Start();

        }
    }
}
