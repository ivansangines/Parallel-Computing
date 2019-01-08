using Mapack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMM
{
    public partial class Form1 : Form
    {
        // reference for equations involved in Gaussian Mixture Model using Expectation Maximization
        // https://brilliant.org/wiki/gaussian-mixture-model/

        int k = 2; // number of clusters
        int dataLength = 400;
        double[] mu = null;  // mean for cluster k
        Random rand = new Random();
        double[] sigma = null;  // standard dev for cluster k
        double[,] pdf = null;   // calculated pdf for each data point based on mean and var for cluster k
        double[,] Gamma = null; // probablity matrix for each data point
                                // i.e., probablity that a data point belongs to cluster i
        double[] phi = null;    // prior probabilities for each cluster

        List<MyPoint> PList = new List<MyPoint>();
        int dimenssions = 2;
        List<SwarmResult> sResults = new List<SwarmResult>();


        public Form1()
        {
            InitializeComponent();
        }

       
        /*
        public double ComputeVariance(double[] data)
        {
            double avg = data.Average();
            double sum = 0;
            foreach (double num in data)
            {
                sum += (num - avg)*(num - avg);
            }
            return sum / data.Length;
        }

        public double Gaussian(double num, double mean, double stddev)  // 1-D gaussian
        {
            double res = (1 / (stddev * Math.Sqrt(2.0 * Math.PI))) * 
                Math.Exp( (-1 * (num - mean) * (num - mean)) / (2 * stddev * stddev));
            return res;
        }
        */
       
       


        private void btnInitialize_Click(object sender, EventArgs e)
        {
            PList.Clear();
            Random rand = new Random();
            
            double meanx0 = 100;
            double meanx1 = 200;
            double meanx2 = 325;
            double meanx3 = 425;

            double meany0 = 75;
            double meany1 = 150;
            double meany2 = 250;
            double meany3 = 350;

            double stddevx0 = 40;
            double stddevx1 = 70;
            double stddevx2 = 80;
            double stddevx3 = 60;
            double stddevy0 = 60;
            double stddevy1 = 80;
            double stddevy2 = 80;
            double stddevy3 = 85;

            int index = 0;

            for (int i = 0; i < dataLength / 4; i++)
            {
                MyPoint pt = new MyPoint();
                double rnum = rand.NextDouble();
                if (rnum < 0.5)
                    pt.X = (int)(rand.NextDouble() * stddevx0 / 2 + meanx0);
                else
                    pt.X = (int)(-1 * rand.NextDouble() * stddevx0 / 2 + meanx0);
                if (rnum < 0.5)
                    pt.Y = (int)(rand.NextDouble() * stddevy0 / 2 + meany0);
                else
                    pt.Y = (int)(-1 * rand.NextDouble() * stddevy0 / 2 + meany0);
                index++;
                PList.Add(pt);
            }

            for (int i = 0; i < dataLength / 4; i++)
            {
                MyPoint pt = new MyPoint();
                double rnum = rand.NextDouble();
                if (rnum < 0.5)
                    pt.X = (int)(rand.NextDouble() * stddevx1 / 2 + meanx1);
                else
                    pt.X = (int)(-1 * rand.NextDouble() * stddevx1 / 2 + meanx1);
                if (rnum < 0.5)
                    pt.Y = (int)(rand.NextDouble() * stddevy1 / 2 + meany1);
                else
                    pt.Y = (int)(-1 * rand.NextDouble() * stddevy1 / 2 + meany1);
                index++;
                PList.Add(pt);
            }

            for (int i = 0; i < dataLength / 4; i++)
            {
                double rnum = rand.NextDouble();
                MyPoint pt = new MyPoint();
                if (rnum < 0.5)
                    pt.X = (int)(rand.NextDouble() * stddevx2 / 2 + meanx2);
                else
                    pt.X = (int)(-1 * rand.NextDouble() * stddevx2 / 2 + meanx2);
                if (rnum < 0.5)
                    pt.Y = (int)(rand.NextDouble() * stddevy2 / 2 + meany2);
                else
                    pt.Y = (int)(-1 * rand.NextDouble() * stddevy2 / 2 + meany2);
                PList.Add(pt);
                index++;
            }

            for (int i = 0; i < dataLength / 4; i++)
            {
                double rnum = rand.NextDouble();
                MyPoint pt = new MyPoint();
                if (rnum < 0.5)
                    pt.X = (int)(rand.NextDouble() * stddevx3 / 2 + meanx3);
                else
                    pt.X = (int)(-1 * rand.NextDouble() * stddevx3 / 2 + meanx3);
                if (rnum < 0.5)
                    pt.Y = (int)(rand.NextDouble() * stddevy3 / 2 + meany3);
                else
                    pt.Y = (int)(-1 * rand.NextDouble() * stddevy3 / 2 + meany3);
                index++;
                PList.Add(pt);
            }
            Visualization.DrawPoints(pic1, PList, 0.7);
            MessageBox.Show("Data initialized for " + PList.Count + " points");
        }

        private void btnSwarms_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            //Creating matrix with points in PList
            Matrix X = new Matrix(dataLength, dimenssions);
            for (int i = 0; i < PList.Count; i++)
            {
                X[i, 0] = PList[i].X;
                X[i, 1] = PList[i].Y;
            }

            
            SwarmSystem ss = null;
            sw.Start();
            for (int i = 2; i < 6; i++)
            {
                ss = new SwarmSystem(i);
                ss.Initialize(PList, i);
                sResults.Add(ss.DoPSO(i, 2, X, pic1));
            }

            sResults.Sort();

            sw.Stop();
            Visualization.DrawClusters(pic1, sResults[0].BestList, sResults[0].SwarmId);
            MessageBox.Show("Time elapsed to compute (ms): " + sw.ElapsedMilliseconds);

            //MessageBox.Show("FIN");

        }

        private void btnClusters_Click(object sender, EventArgs e)
        {
            try
            {
                int clusters = Int32.Parse(txtCluster.Text);
                //pic1.Image = null;
                if (clusters > 1 && clusters < 6)
                {
                    
                    for (int i=0; i < sResults.Count; i++)
                    {
                        if (sResults[i].SwarmId == clusters)
                        {
                            Visualization.DrawClusters(pic1, sResults[i].BestList, sResults[i].SwarmId);
                        }
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong input.");
            }

        }
    }
    
}
