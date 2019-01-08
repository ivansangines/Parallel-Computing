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

namespace MatrixMultiply
{
    public partial class Form1 : Form
    {
        double[,] A = null;
        double[,] B = null;
        double[,] C = null;
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnInitializeMatrix_Click(object sender, EventArgs e)
        {
            int size = 1000;
            A = new double[size, size];
            B = new double[size, size];
            C = new double[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    A[i, j] = rand.NextDouble() * 100;
                    B[i, j] = rand.NextDouble() * 50;
                }
            
        }

        public double[,] MatrixMultiply(double[,] X, double[,] Y)
        {
            double[,] Res = new double[X.GetLength(0), X.GetLength(0)];
            int size = X.GetLength(0);
            //for (int i = 0; i < size; i++)
            Parallel.For(0, size, (i) =>

            {
                for (int k = 0; k < size; k++)
                //for (int j = 0; j < size; j++)
                {
                    for (int j = 0; j < size; j++)
                    //for (int k = 0; k < size; k++)
                    {
                        Res[i, j] = Res[i, j] + X[i, k] * Y[k, j];
                    }
                }
                //}
            });
            return Res;
        }

        private void btnMatrixMultiply_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            C = MatrixMultiply(A, B);
            sw.Stop();
            MessageBox.Show("Time taken = " + sw.ElapsedMilliseconds.ToString());
        }
    }
}
