using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecondWCFClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMatrix_Click(object sender, EventArgs e)
        {
            MM2.MyMath2Client mmc = new MM2.MyMath2Client(); // proxy
            MM2.Matrix A = mmc.InitMatrix(2, 2);
            A.Data[0][0] = 5; A.Data[0][1] = 7; A.Data[1][0] = 3; A.Data[1][1] = 4;
            MM2.Matrix B = mmc.InitMatrix(2, 2);
            B.Data[0][0] = 3; B.Data[0][1] = 5; B.Data[1][0] = 1; B.Data[1][1] = 6;
            MM2.Matrix C = mmc.MultiplyMatrix(A, B);
            string out1 = "";
            for (int i = 0; i < C.Rows; i++)
            {
                for (int j = 0; j < C.Cols; j++)
                {
                    out1 += "C[" + i.ToString() + "][" + j.ToString() + "]=" +
                   C.Data[i][j].ToString() + " ";
                }
                out1 += "\n";
            }
            MessageBox.Show(out1);
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            ES.EmployeeServiceClient esc = new ES.EmployeeServiceClient();
            gv1.DataSource = esc.GetAllEmployees();
            gv1.Refresh();

        }
    }
}
