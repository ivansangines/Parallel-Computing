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
using LUDecomposition;

namespace LUDecompoistion
{
    public partial class Form1 : Form
    {
        int full_Size; //size of the full matrix
        int blocks_Size; //size of the blocks
        int blocks_Number; //number of blocks needed
        int sub_Size; //size of the matrix containing the blocks

        Matrix Y;
        Matrix X;
        Matrix B;
        Matrix[,] allBlocks; //matrix containing all the blocks
        Matrix[,] lBlocks; //matrix containing all the L blocks
        Matrix full_L; //matrix containing all the concatenated L blocks
        Matrix fullL_Inverse; //inverse of the full L matrix
        Matrix[,] uBlocks; //matrix containing all the U blocks
        Matrix full_U; //matrix containing all the concatenated U blocks
        Matrix fullU_Inverse; //inverse of the full U matrix
        


        public Form1()
        {
            InitializeComponent();
        }

        private void btnComputeLU_Click(object sender, EventArgs e)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Initialize();

            

            for (int poss = 0; poss < sub_Size; poss++)
            {
                double[,] L = new double[blocks_Size, blocks_Size];
                double[,] U = new double[blocks_Size, blocks_Size];
                Matrix inverseL;
                Matrix inverseU;

                //L AND U AT THE DIAGONAL               
                allBlocks[poss, poss].LUDecompose(L, U);

                
                lBlocks[poss, poss] = new Matrix(L);
                uBlocks[poss, poss] = new Matrix(U);
                
                //DIAGONAL L AND U INVERSE
                inverseL = new Matrix(lBlocks[poss, poss].LInverse());
                inverseU = new Matrix(uBlocks[poss, poss].UInverse());

                object olock = new object();

                //COMPUTING L AND U IN PARALLEL (DIAGONAL AND DIAGONAL INVERS WERE ALREADY COMPUTED BEFORE
                Parallel.For((poss + 1), sub_Size, (j) =>
                //for (int j=poss+1; j<sub_Size; j++)
                {
                    //lock (olock)
                    //{
                        uBlocks[poss, j] = (inverseL * allBlocks[poss, j]);
                    //}
                    //lock (olock)
                    //{
                        lBlocks[j, poss] = (allBlocks[j, poss] * inverseU);
                    //}                                     
                });

                if (poss < (sub_Size - 1))
                {
                    UpgradeMatrix(poss + 1);
                }

            }

            //creating large matrix
            CreateLargeMatrix();

            //getting the full inverse matrixs
            fullL_Inverse = new Matrix(full_L.LInverse());
            fullU_Inverse = new Matrix(full_U.UInverse());

            //getting results
            Y = fullL_Inverse * B;
            X = fullU_Inverse * Y;

            timer.Stop();

            MessageBox.Show(timer.ElapsedMilliseconds + "ms");

            MessageBox.Show(X.ShowX());



        }

        public void UpgradeMatrix(int pos)
        {
            for (int i = pos; i < sub_Size; i++)
            {
                Matrix result = new Matrix(blocks_Size, blocks_Size);
                Matrix result2 = new Matrix(blocks_Size, blocks_Size);

                for (int k = 0; k < pos; k++) //generating the results for rows and cols update
                {
                    result += lBlocks[pos, k] * uBlocks[k, i]; //result used to update rows

                    result2 += lBlocks[i, k] * uBlocks[k, pos]; //result used to update cols
                }
                allBlocks[pos, i] = allBlocks[pos, i] - result;    //update row

                if (i != pos) //updating the cols. However, we have already updated the diagonal while doing the rows
                {             
                    allBlocks[i, pos] = allBlocks[i, pos] - result2;  //update column

                }

            }
        }

        public void Initialize()
        {
            /*
            full_Size = 4;
            blocks_Number = 4;
            blocks_Size = 2;
            sub_Size = 2;
            */
            
            full_Size = (int)Math.Pow(2, 9);            
            blocks_Number = (int)Math.Pow(2, 4);
            blocks_Size = (int)Math.Sqrt(full_Size * full_Size / blocks_Number);
            sub_Size = (int)Math.Sqrt(blocks_Number);
            


            //initialize Matrixs with right sizes
            full_L = new Matrix(full_Size, full_Size);
            fullL_Inverse = new Matrix(full_Size, full_Size);
            full_U = new Matrix(full_Size, full_Size);
            fullU_Inverse = new Matrix(full_Size, full_Size);
            //matrixs containing blocks, we will use sub_size
            allBlocks = new Matrix[sub_Size, sub_Size];
            lBlocks = new Matrix[sub_Size, sub_Size];
            uBlocks = new Matrix[sub_Size, sub_Size];

            //matrix of just one column since they just have variables or results
            X = new Matrix(full_Size, 1);
            B = new Matrix(full_Size, 1);
            Y = new Matrix(full_Size, 1);

            
            //fill lBlocks and uBlocks with empty matrixs of size of the blocks
            for (int r=0; r<sub_Size; r++)
            {
                for (int col=0; col<sub_Size; col++)
                {
                    lBlocks[r, col] = new Matrix(blocks_Size, blocks_Size);
                    uBlocks[r, col] = new Matrix(blocks_Size, blocks_Size);
                }
            }

            
            Random rand = new Random();
            double num = 0.0;

            //Generating random results
            for (int w = 0; w < full_Size; w++)
            {
                num = (rand.NextDouble() - 0.5) * 15;//substacting 0.5 to have some of the numbers negative. 
                                                     // Multiplying by 15 so we have numbers bigger than 1.
                B[w, 0] = num;
            }

            //Generating blocks with random numbers
            object olock = new object();            
            Parallel.For(0, sub_Size, (i) =>
            {
                for (int j = 0; j < sub_Size; j++)
                {
                    lock (olock)
                    {
                        Matrix m1 = new Matrix(blocks_Size, blocks_Size);
                        for (int h = 0; h < blocks_Size; h++)
                        {
                            for (int w = 0; w < blocks_Size; w++)
                            {
                                num = (rand.NextDouble() - 0.5) * 10; //substacting 0.5 to have some of the numbers negative. 
                                                                     // Multiplying by 10 so we have numbers bigger than 1.
                                m1[h, w] = num;
                                
                            }
                        }
                        //MessageBox.Show("one");
                        allBlocks[i, j] = m1;
                        //MessageBox.Show("we are in:"+i+","+j + ":" + allBlocks[i,j].ToString());
                    }
                }
            });

            

            /*
            B[0, 0] = 5; B[1, 0] = 7; B[2, 0] = -3; B[3, 0] = 1.75; //resutls of the equations

            Matrix m1 = new Matrix(2, 2);
            m1[0, 0] = 1.5; m1[0, 1] = 0.25;
            m1[1, 0] = 0.25; m1[1, 1] = 3;
            allBlocks[0, 0] = m1;

            Matrix m2 = new Matrix(2, 2);
            m2[0, 0] = 1; m2[0, 1] = 3;
            m2[1, 0] = 4.5; m2[1, 1] = 0.75;
            allBlocks[0, 1] = (m2);

            Matrix m3 = new Matrix(2, 2);
            m3[0, 0] = 0.75; m3[0, 1] = 6;
            m3[1, 0] = 12; m3[1, 1] = 1;
            allBlocks[1, 0] = m3;

            Matrix m4 = new Matrix(2, 2);
            m4[0, 0] = 2.75; m4[0, 1] = 8.5;
            m4[1, 0] = 9; m4[1, 1] = 15;
            allBlocks[1, 1] = m4;

            //Expected results for the variables: x1=-14.48, x2=-12.67, x3=9.68, x4=6.73

            */


        }

        //creating the full matrix using blocks (CONCATENATING)
        public void CreateLargeMatrix()
        {
            //we are going to go throught the sub matrixs L and U with blocks and create a big matrix
            //rows of the sub matrixs
            object olock = new object();

            Parallel.For(0, sub_Size, (h) =>
            //for (int h = 0; h < sub_Size; h++)
            {
                //columns of the sub matrixs
                for (int w = 0; w < sub_Size; w++)
                {
                    //going throught the block rows
                    for (int i = 0; i < blocks_Size; i++)
                    {
                        //going through the blocks columns
                        for (int j = 0; j < blocks_Size; j++)
                        {
                            lock (olock)
                            {
                                full_L[h * blocks_Size + i, w * blocks_Size + j] = lBlocks[h, w][i, j];
                            }
                            lock (olock)
                            {
                                full_U[h * blocks_Size + i, w * blocks_Size + j] = uBlocks[h, w][i, j];
                            }
                        }
                    }
                }
            });

            //showing full L and U Matrixs
            //MessageBox.Show(full_L.ToString());
            //MessageBox.Show(full_U.ToString());

        }
        
        private void btnLInverse_Click(object sender, EventArgs e)
        {
            double[,] L = new double[5, 5];
            double[,] U = new double[5, 5];
            Matrix m1 = new Matrix(5, 5);
            m1[0, 0] = 0.5; m1[0, 1] = 2; m1[0, 2] = 1; m1[0, 3] = 4; m1[0, 4] = 2;
            m1[1, 0] = 1.25; m1[1, 1] = 7; m1[1, 2] = 3.5; m1[1, 3] = 13; m1[1, 4] = 0.5;
            m1[2, 0] = 0.5; m1[2, 1] = 5; m1[2, 2] = 3.5; m1[2, 3] = 10.5; m1[2, 4] = 8;
            m1[3, 0] = 0.5; m1[3, 1] = 6; m1[3, 2] = 6; m1[3, 3] = 19; m1[3, 4] = 3;
            m1[4, 0] = 1; m1[4, 1] = 3; m1[4, 2] = 2; m1[4, 3] = 7; m1[4, 4] = 6;

            double err = 0;
            m1.LUDecompose(L, U);
            string out1 = "L Matrix:\n";
            for (int i = 0; i < L.GetLength(0); i++)
            {
                for (int j = 0; j < L.GetLength(1); j++)
                {
                    out1 += L[i, j].ToString() + " ";
                }
                out1 += "\n";
            }
            MessageBox.Show(out1);

            Matrix m2 = new Matrix(L);
            double[,] Linv = m2.LInverse();
            out1 = "";
            for (int i = 0; i < Linv.GetLength(0); i++)
            {
                for (int j = 0; j < Linv.GetLength(1); j++)
                {
                    out1 += Linv[i, j].ToString() + " ";
                }
                out1 += "\n";
            }
            MessageBox.Show(out1);

        }

        private void btnUInverse_Click(object sender, EventArgs e)
        {
            double[,] L = new double[5, 5];
            double[,] U = new double[5, 5];
            Matrix m1 = new Matrix(5, 5);
            m1[0, 0] = 0.5; m1[0, 1] = 2; m1[0, 2] = 1; m1[0, 3] = 4; m1[0, 4] = 2;
            m1[1, 0] = 1.25; m1[1, 1] = 7; m1[1, 2] = 3.5; m1[1, 3] = 13; m1[1, 4] = 0.5;
            m1[2, 0] = 0.5; m1[2, 1] = 5; m1[2, 2] = 3.5; m1[2, 3] = 10.5; m1[2, 4] = 8;
            m1[3, 0] = 0.5; m1[3, 1] = 6; m1[3, 2] = 6; m1[3, 3] = 19; m1[3, 4] = 3;
            m1[4, 0] = 1; m1[4, 1] = 3; m1[4, 2] = 2; m1[4, 3] = 7; m1[4, 4] = 6;

            double err = 0;
            m1.LUDecompose(L, U);
            string out1 = "U\n";
            for (int i = 0; i < U.GetLength(0); i++)
            {
                for (int j = 0; j < U.GetLength(1); j++)
                {
                    out1 += U[i, j].ToString() + " ";
                }
                out1 += "\n";
            }
            MessageBox.Show(out1);

            Matrix m2 = new Matrix(U);
            double[,] Uinv = m2.UInverse();
            out1 = "Uinv\n";
            for (int i = 0; i < Uinv.GetLength(0); i++)
            {
                for (int j = 0; j < Uinv.GetLength(1); j++)
                {
                    out1 += Uinv[i, j].ToString() + " ";
                }
                out1 += "\n";
            }
            MessageBox.Show(out1);
        }
        
    }
}
