using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LUDecomposition
{
    class Matrix  // uses inner class to delegate the work to a function
    {             // for launching it as a separate thread and to
                  // pass data to it and collect results from it
        int m;
        public int M
        {
            get { return m; }
        }
        int n;
        public int N
        {
            get { return n; }
        }

        double[,] data = null; //indexer

        public double this[int i, int j]
        {
            get { return data[i,j]; }
            set { data[i,j] = value; }
        }


        public Matrix(int m1, int n1)
        {
            data = new double[m1, n1];
            m = m1;
            n = n1;
        }

        public Matrix(double[,] dt)
        {
            data = dt;
            m = dt.GetLength(0);
            n = dt.GetLength(1);
        }

        public static Matrix operator *(Matrix A, Matrix B)
        {
            Matrix mres = new Matrix(A.m, B.n);
            Thread[] thArr = new Thread[A.m];
            for (int i = 0; i < A.m; i++)
            {
                //for (int j = 0; j < B.n; j++)
                //    for (int k = 0; k < A.n; k++)
                //        mres.data[i, j] += A.data[i, k] * B.data[k, j];
                MatrixMul mm = new MatrixMul();
                mm.M1 = A;
                mm.M2 = B;
                mm.Mress = mres;
                mm.Iter = i;
                thArr[i] = new Thread(new ThreadStart(mm.ComputeRow));
                thArr[i].Start();

            }

            for (int p = 0; p < A.m; p++)
            {
                thArr[p].Join();  // wait for all threads to finish
            }

            return mres;

        }

        public static Matrix operator +(Matrix A, Matrix B)
        {
            int rows = A.m;
            int columns = A.n;

            Matrix X = new Matrix(rows, columns);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    X[i, j] = A[i, j] + B[i, j];
                }
            }
            return X;
        }

        public static Matrix operator -(Matrix A, Matrix B)
        {
            int rows = A.m;
            int columns = A.n;

            Matrix X = new Matrix(rows, columns);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    X[i, j] = A[i, j] - B[i, j];
                }
            }
            return X;
        }

        public void LUDecompose(double[,]L, double[,] U)  // operates on M
        {
            if (m != n)
                throw new Exception("width and column dimensions are not the same..");

            // copy data into A matrix
            double[,] A = new double[n, n];
            A = (double [,])data.Clone();

            for (int k = 0; k < n; k++)
            {
                U[k, k] = data[k, k];
                for (int j = k+1; j < n; j++)
                {
                     U[k, j] = data[k, j];
                }
                for (int i = k; i < n; i++)
                {
                    if (i == k)
                        L[i, k] = 1;
                    else
                        L[i, k] = data[i, k] / U[k, k];
                }
                for (int i = k+1; i < n; i++)
                {
                    for (int j = k+1; j < n; j++)
                        data[i, j] = data[i, j] - L[i, k] * U[k, j];
                   
                }
                
            }
            /*
            // verify if LU decomp is correct
            double [,] res = new double[n,n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    for (int k = 0; k < n; k++)
                        res[i, j] += L[i, k] * U[k, j];
            error = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    error += Math.Abs(res[i, j] - A[i, j]);
            */
        }

        public double[,] LInverse()  // assumes lower triangular matrix
        {   // with 1 in diagonals
            // see handout on computing inverses of triangular matrices on CS590 web site
            // the following code implements the algorithm described in the handout
            if (m != n)
                throw new Exception("Matrix is not square..");

            double[,] L = (double[,])data.Clone();

            for (int i = 0; i < n; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    double sum = 0;
                    if (i == (j + 1))  // first diagonal below main diagonal
                    {
                        for (int k = 0; k < i; k++)
                        {
                            sum += L[i, k] * L[k, j];
                        }
                    }
                    else if (i > (j+2))  //  third diagonal and below
                    {
                        for (int k = j + 1; k <= i; k++)
                        {
                            sum += L[i, k] * data[k, j];
                        }
                    }
                    else if (i > (j+1))  // second diagonal
                    {
                        for (int k = j + 1; k < i; k++)
                        {
                            sum += L[i, k] * L[k, j];
                        }
                    }
                    if (i == (j + 1))
                        L[i, j] = 0 - sum;
                    else if (i > (j +2))
                        L[i,j]= -1 * sum;
                    else if (i > (j + 1))
                        L[i, j] = sum - data[i, j];
                    else
                        L[i, j] = -1*sum ;
                }

            }
            return L;  // L contains inverse of L
        }

        
        public double[,] UInverse()  // assumes upper triangular matrix
        {  // see handout on computing inverses of triangular matrices on CS590 web site
            if (m != n)
                throw new Exception("Matrix is not square..");
            double[,] U = (double[,])data.Clone();
            // find the transpose of the matrix
            double[,] UT = this.Transpose();   // convert U to L
            double[,] D = new double[m, n];  // diagonal matrix
            for (int i = 0; i < m; i++)      
                D[i, i] = 1 / UT[i, i];  // D contains Dinverse
            
            double [,] C = new double[m,n];  // compute C = Dinverse * transpose of U
            for (int i = 0; i < n; i++)      // to make diagonal entries of C to be 1
                for (int j = 0; j < n; j++)
                    for (int k = 0; k < n; k++)
                        C[i, j] +=  D[i,k]* UT[k, j] ;  // now C is like transpose of U but diagonal 1's

            double[,] L = new double[n, n];   // copy C into L. We already know how to do Linverse
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    L[i, j] = C[i, j];
            //----compute Linv, then multiply by Dinv
            for (int i = 0; i < n; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    double sum = 0;
                    if (i == (j + 1))  // first diagonal below main diagonal
                    {
                        for (int k = 0; k < i; k++)
                        {
                            sum += L[i, k] * L[k, j];
                        }
                    }
                    else if (i > (j + 2))  //  third diagonal and below
                    {
                        for (int k = j + 1; k <= i; k++)
                        {
                            sum += L[i, k] * C[k, j];
                        }
                    }
                    else if (i > (j + 1))  // second diagonal
                    {
                        for (int k = j + 1; k < i; k++)
                        {
                            sum += L[i, k] * L[k, j];
                        }
                    }
                    if (i == (j + 1))
                        L[i, j] = 0 - sum;
                    else if (i > (j + 2))
                        L[i, j] = -1 * sum;
                    else if (i > (j + 1))
                        L[i, j] = sum - C[i, j];
                    else
                        L[i, j] = -1 * sum;
                }

            }
 
            double[,] Res = new double[n, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                        Res[i,j] += L[i, k] * D[k,j];  // multiply L which is Cinverse by Dinverse 
                }
                
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    U[i, j] = Res[j, i];  // transpose to obtain Uinverse
                }
            }
            return U;  // U now contains inverse of U
        }

        public double[,] Transpose()
        {
            // transposes the matrix i.e, rows become columns and columns become rows
            double[,] T = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    T[i, j] = data[j, i];
                }
            }
            return T;
        }

        public string ShowX()
        {
            string out1 = "";
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                    // out1 += data[i, j].ToString() + "\t";
                    out1 += "X" + i + ": " + String.Format("{0:f2}", data[i, j]);
                out1 += "\n";
            }
            return out1;
        }


        public override string ToString()
        {
            string out1 = "";
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                    //out1 += data[i, j].ToString() + " \t";
                    out1 += String.Format("{0,5:f2}", data[i, j]);
                out1 += "\n";
            }
            return out1;
        }

        class MatrixMul
        {
            Matrix m1;
            public Matrix M1
            {
                get { return m1; }
                set { m1 = value; }
            }
            Matrix m2;
            public Matrix M2
            {
                get { return m2; }
                set { m2 = value; }
            }

            Matrix mress;
            public Matrix Mress
            {
                get { return mress; }
                set { mress = value; }
            }

            int iter;
            public int Iter
            {
                get { return iter; }
                set { iter = value; }
            }

            public void ComputeRow()
            {
                for (int k = 0; k < M1.n; k++)  // changing order still produces
                for (int j = 0; j < M2.n; j++)  // correct result
                   // for (int k = 0; k < M1.n; k++)
                        mress.data[iter, j] += M1.data[iter, k] * M2.data[k, j];

            }

        }

    }
}
