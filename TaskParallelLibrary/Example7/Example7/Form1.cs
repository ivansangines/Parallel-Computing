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

namespace Example7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Parallel.Invoke(
         () => MessageBox.Show("First Task.."),
         () => { Thread.Sleep(3000); MessageBox.Show("Second Task"); },
         () => { Thread.Sleep(4000); MessageBox.Show("Third Task"); }
            );

        }
    }
}
