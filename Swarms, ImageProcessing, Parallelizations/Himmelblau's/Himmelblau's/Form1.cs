using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Himmelblau_s
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numSwarmsToLaunch = 50;
            Task<SwarmResult>[] TaskArr = new Task<SwarmResult>[numSwarmsToLaunch];
            for (int i = 0; i < TaskArr.Length; i++)
            {
                TaskArr[i] = Task.Factory.StartNew<SwarmResult>( 
                (obj) =>
                {
                    SwarmSystem ss = new SwarmSystem((int)obj);
                    ss.Initialize();
                    SwarmResult sr = ss.DoPSO();
                    return sr;
                }, i);
            }
            //Task.WaitAll(TaskArr); // wait for all tasks to finish
            List<SwarmResult> RList = new List<SwarmResult>();
            Task tskFinal = Task.Factory.ContinueWhenAll(TaskArr,(tsks) =>
            {
                Console.WriteLine(tsks.Length.ToString() + " tasks");
                for (int i = 0; i < tsks.Length; i++)
                    RList.Add(tsks[i].Result);
            });
            tskFinal.Wait();
            RList.Sort();
            //List<SwarmResult> Res = new List<SwarmResult>();
            //Res = RList.Distinct(new SwarmResult());            
            var Res= RList.Distinct(new SwarmResult()).ToList();
            dg1.DataSource = RList;
            dg1.Refresh();
            lblResult1.Text = Res[0].ToString();
            lblResult2.Text = Res[1].ToString();
            lblResult3.Text = Res[2].ToString();
            lblResult4.Text = Res[3].ToString();
            

        }
    }
}
