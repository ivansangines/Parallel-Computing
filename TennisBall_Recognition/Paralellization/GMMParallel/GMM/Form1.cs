using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMM
{
    public partial class Form1 : Form
    {
        bool ready = false;
        int k = 2; // number of clusters
        int dataSize = 10000;
        double[] mu = null; // mean for cluster k
        Random rand = new Random();
        double[] sigma = null; // standard dev for cluster k
        double[,] pdf = null; // calculated pdf for each data point based on mean and var for cluster k
        double[,] Gamma = null; // probablity matrix for each data point (it will contain data point and its probability for each cluster)
                                 // i.e., probablity that a data point belongs to cluster i
        double[] phi = null; // prior probabilities for each cluster

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGMM_Click(object sender, EventArgs e)
        {
            mu = new double[k];
            sigma = new double[k]; // standard dev for cluster k
            mu[0] = 10; mu[1] = 15;
            sigma[0] = 1; sigma[1] = 3;
            phi = new double[k]; // prior probabilities for each cluster
            Gamma = new double[dataSize, k]; // probablity matrix for each data point
                                             // i.e., probablity that a data point belongs to cluster i
            pdf = new double[dataSize, k]; // calculated pdf for each data point based on mean and var for cluster k

            //initializing 10 data # close to 10 and 10 data # >15
            double[] X1 = new double[5000];
            for (int i = 0; i < 5000; i++)
                X1[i] = rand.NextDouble() * sigma[0] + mu[0]; //will create random numbers all close to 10 since *1 and +10
            double[] X2 = new double[5000];
            for (int i = 0; i < 5000; i++)
                X2[i] = rand.NextDouble() * sigma[1] + mu[1]; //will create random numbers bigger than 15 since *+ and +15

            double[] X = X1.Concat(X2).ToArray<double>(); // catenate X1 and X2

            // ----------Initialization step - randonly select k data poits to act as means
            List<int> RList = new List<int>();
            for (int i = 0; i < k; i++)
            {
                int rpos = rand.Next(X.Length); //return ran number less than X.length
                if (RList.Contains(rpos))
                    rpos = rand.Next(X.Length);
                mu[i] = X[rpos];
            }
            // set the variance of each cluster to be the overall variance
            double varianceOfData = ComputeVariance(X);
            for (int i = 0; i < k; i++)
            {
                sigma[i] = Math.Sqrt(varianceOfData);
            }
            // set prior probablities of each cluster to be uniform
            for (int i = 0; i < k; i++)
            {
                phi[i] = 1.0 / k;
            }
            //--------------------------end initialization-------------------------------

            Stopwatch sw = new Stopwatch();
            sw.Start();
            // ---------------------------Expectation Maximization-----------------------

            //Parallel.For(0, 1000, (n) => //NO RISK WHILE UPDATING MU????
            for (int n = 0; n < 1000; n++)
            {
                //---------perform Expectation step---------------------
                //for (int i = 0; i < X.Length; i++)
                Parallel.For(0, X.Length, (i)=>
                {
                    for (int kk = 0; kk < k; kk++)
                    {
                        pdf[i, kk] = Gaussian(X[i], mu[kk], sigma[kk]);
                    }
                });
                double[] Gdenom = new double[X.Length];
                for (int i = 0; i < X.Length; i++) // denominator for Gamma
                {
                    double sum = 0;
                    for (int kk = 0; kk < k; kk++)
                    {
                        sum = sum + phi[kk] * pdf[i, kk];
                    }
                    Gdenom[i] = sum;
                }
                //for (int i = 0; i < X.Length; i++)
                Parallel.For(0,X.Length,(i)=>
                {
                    for (int kk = 0; kk < k; kk++)
                    {
                        Gamma[i, kk] = (phi[kk] * pdf[i, kk]) / Gdenom[i];
                    }
                });
                //-------------------end Expectation--------------------

                //---------perform Maximization Step--------------------
                //----------update phi--------------
                for (int kk = 0; kk < k; kk++)
                {
                    double sum = 0;
                    for (int i = 0; i < X.Length; i++)
                    {
                        sum += Gamma[i, kk];
                    }
                    phi[kk] = sum / (X.Length);
                }
                //---------------------------------

                //-------------update mu-----------
                double[] MuNumer = new double[X.Length];
                for (int kk = 0; kk < k; kk++)
                {
                    double sum = 0;
                    for (int i = 0; i < X.Length; i++)
                    {
                        sum += Gamma[i, kk] * X[i];
                    }
                    MuNumer[kk] = sum;
                }
                double[] MuDenom = new double[X.Length];
                for (int kk = 0; kk < k; kk++)
                {
                    double sum = 0;
                    for (int i = 0; i < X.Length; i++)
                    {
                        sum += Gamma[i, kk];
                    }
                    MuDenom[kk] = sum;
                }
                for (int i = 0; i < k; i++)
                    mu[i] = MuNumer[i] / MuDenom[i];
                //-----------------------------------

                //-------------update sigma----------
                double[] VarianceNumer = new double[X.Length];
                for (int kk = 0; kk < k; kk++)
                {
                    double sum = 0;
                    for (int i = 0; i < X.Length; i++)
                    {
                        sum += Gamma[i, kk] * (X[i] - mu[kk]) * (X[i] - mu[kk]);
                    }
                    VarianceNumer[kk] = sum;
                }
                for (int i = 0; i < k; i++)
                    sigma[i] = Math.Sqrt(VarianceNumer[i] / MuDenom[i]);
                //--------------end update Sigma--------
                //---------------end Maximization-------------------------------
            }
            sw.Stop();
            var G = Gamma;
            ready = true;
            MessageBox.Show("End Expectation Maximization, time elapsed (ms): "+sw.ElapsedMilliseconds);
        }


        public double ComputeVariance(double[] data)
        {
            double avg = data.Average();
            double sum = 0;
            foreach (double num in data)
            {
                sum += (num - avg) * (num - avg);
            }
            return sum / data.Length;
        }

        public double Gaussian(double num, double mean, double stddev) // 1-D gaussian
        {
            double res = (1 / (stddev * Math.Sqrt(2.0 * Math.PI))) * Math.Exp((-1 * (num - mean) * (num - mean)) / (2 * stddev * stddev));
            return res;
        }

        private void btnClass_Click(object sender, EventArgs e)
        {
            if (ready)
            {
                double num = double.Parse(txtNum.Text);
                double denom = 0;
                for (int i = 0; i < k; i++)
                    denom += phi[i] * Gaussian(num, mu[i], sigma[i]);
                double[] C = new double[k]; // p(Ci|x) - probablity x belongs to cluster Ci
                for (int i = 0; i < k; i++)
                    C[i] = phi[i] * Gaussian(num, mu[i], sigma[i]) / denom; //storing probability for each cluster
                string out1 = "";
                int cnum = 0;
                foreach (double p in C)
                {
                    out1 += "Cluster " + cnum.ToString() + " Probab. = " + p.ToString() + "\n";
                    cnum++;
                }
                MessageBox.Show(out1);
            }
            else
            {
                MessageBox.Show("You must start Maximitation first");
            }
        }
    }
}

