using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PubSubClient
{
    public partial class Form1 : Form
    {
        STKClient stkC = new STKClient();
        int myId = 0;

        public Form1()
        {
            InitializeComponent();
        }
        

        private void btnTestCallback_Click(object sender, EventArgs e)
        {
            try
            {
                CBClient cbc = new CBClient();                
                cbc.CallLongCompute(int.Parse(txtA.Text),
                int.Parse(txtB.Text), txtClientID.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSubscribe_Click(object sender, EventArgs e)
        {
            try
            {
                //stkC.SubscribeToPriceChange("IBM", 128, myId);

                //Using Forms2 Information
                Form2 form2 = new Form2();
                form2.ShowDialog();
                stkC.SubscribeToPriceChange(form2.Symbol, form2.Price, myId);
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnChangePrice_Click(object sender, EventArgs e)
        {
            PS.PriceChangeClient pcc = new PS.PriceChangeClient();
            pcc.ChangeStockPrice("IBM", double.Parse(txtNewPrice.Text));

        }

        private void Form1_Load(object sender, EventArgs e)

        {
            myId = new Random((int)DateTime.Now.Ticks).Next();
            this.Text = myId.ToString();
        }

        private void btnUnsubscribe_Click(object sender, EventArgs e)
        {
            try
            {
                stkC.UnSubscribeToPriceChange("IBM");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                stkC.UnSubscribeToPriceChange("IBM");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
