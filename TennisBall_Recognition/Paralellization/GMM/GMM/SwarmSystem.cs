using Mapack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMM
{
    class SwarmSystem
    {
        public SwarmSystem(int snum)
        {
            this.swarmNum = snum;
        }
        int swarmNum;
        public int SwarmNum
        {
            get { return swarmNum; }
        }
        public List<Particle> ParticleList = new List<Particle>();
        public double[] Px { get; set; } //size same as number of clusters
        public double[] Py { get; set; }
        public double[] Gx { get; set; }
        public double[]  Gy { get; set; }
        List<int> index = new List<int>();
        public GMM_NDim myGMM { get; set; }
        public List<MyPoint> PList;
        public List<MyPoint> BestPList;
        public List<MyPoint> tempPList;

        public void Initialize(List<MyPoint> pointsList, int clus)
        {
            this.PList = new List<MyPoint>(pointsList);
            for (int a=0; a < this.PList.Count; a++)
            {
                index.Add(a);
            }
            Random ran = new Random();
            double num;

            //LIST OF 5(CAN BE ANY #) PARTICLES
            //EACH PARTICLE HAS #CLUSTERS COORDINATES
            for (int i = 0; i < 5; i++) // 50 particles in swarm
            {
                Particle p = new Particle(clus);
                p.W = 0.73;
                p.C1 = 1.4;
                p.C2 = 1.5;
                p.setPsorted(pointsList);

                //Create #clus 
                for (int k=0; k<clus; k++)
                {
                    int ind = ran.Next(index.Count);
                    
                    
                    p.Xx[k] = this.PList[index[ind]].X;
                    p.Xy[k] = this.PList[index[ind]].Y;

                    index.RemoveAt(ind); //remove the num selected so it is not selected again

                    num = ran.NextDouble();
                    p.Vx[k] = ran.NextDouble() * 5;
                    p.Vy[k] = ran.NextDouble() * 5;
                    num = ran.NextDouble();
                    if (num > 0.5)
                    {
                        p.Vx[k] = -1 * p.Vx[k];
                        p.Vy[k] = -1 * p.Vy[k];
                    }

                    ParticleList.Add(p);

                }                
            }
        }

        public double FunctionToSolve(double[] xsig, double[] ysig, int[] clusterCount)
        {
            double result = 0;
            int k = xsig.Length;
            for (int i = 0; i < xsig.Length; i++)
                result += xsig[i] + ysig[i];
            int datasize = 0;
            for (int i = 0; i < clusterCount.Length; i++)
                datasize += clusterCount[i];
            double expextePerCluster = (double)(datasize / k);
            for (int i = 0; i < clusterCount.Length; i++)
            {
                result += Math.Abs((clusterCount[i] / expextePerCluster) - 1) * (datasize / k);
            }
            return result;

        }

        public SwarmResult DoPSO(int clus, int dim, Matrix X, PictureBox pan) // Particle movement to achieve
        { // for particle swarm optimization
            
            Gx = ParticleList[0].Xx;
            Gy = ParticleList[0].Xy;

            //set best value to the one from the first particle at the start
            double tempValue = prepareGMMND(clus, dim, X, ParticleList[0]);

            //will be the best result base on the function to evaluate  
            SwarmResult final = new SwarmResult(clus, tempValue);

            //best result of the particles used at the moment
            SwarmResult temp;

            //////////////////////////////////////////////////////////////////////////////////////////////////7

            for (int i = 0; i < 5; i++) // 1000 ietrations
            {
                // find best position in the swarm
                Px = ParticleList[0].Xx;
                Py = ParticleList[0].Xy;
                double initialValue = prepareGMMND(clus, dim, X, ParticleList[0]);
                this.BestPList = new List<MyPoint>(PList);
                temp = new SwarmResult(clus, initialValue);

                //Find best of particles using
                foreach (Particle pt in ParticleList)
                {
                    double partResult = prepareGMMND(clus, dim, X, pt);
                    if (partResult < temp.FunctionValue)
                    {
                        Px = pt.Xx;
                        Py = pt.Xy;
                        temp.FunctionValue = partResult;
                        tempPList = new List<MyPoint>(PList);
                    }
                }
                //Find final best
                if (temp.FunctionValue < final.FunctionValue)
                {
                    Gx = Px;
                    Gy = Py;
                    final.FunctionValue = temp.FunctionValue;
                    this.BestPList = new List<MyPoint> (PList);
                }
                //Change position of each particle of the ParticleList
                foreach (Particle pt in ParticleList)
                {
                    pt.UpdateVelocity(Px, Py, Gx, Gy);
                    pt.UpdatePosition();
                }
            }

            //SwarmResult sr = new SwarmResult(clus, final.FunctionValue);
            //Visualization.DrawClusters(pan, PList, myGMM, 2);
            final.BestList = new List<MyPoint>(this.BestPList);
            return final;
        }

        public double prepareGMMND(int clus, int dim, Matrix X, Particle pt)
        {
            myGMM = new GMM_NDim(clus, dim, X);
            //One mu for each dimenssion
            //The length og mu is the number of clusters
            int[] xMu = new int[clus];
            int[] yMu = new int[clus];

            for (int k = 0; k < clus; k++)

            {
                xMu[k] = (int)pt.Xx[k];
                yMu[k] = (int)pt.Xy[k];
            }

            myGMM.ComputeGMM_ND(xMu, yMu);

            double[] Xsi = new double[clus];
            double[] Ysi = new double[clus];

            for (int k = 0; k < clus; k++)
            {
                Xsi[k] = Math.Sqrt(Math.Abs(myGMM.sigma[k][0, 0]));
                Ysi[k] = Math.Sqrt(Math.Abs(myGMM.sigma[k][0, 1]));
            }

            int[] particlesInCLuster = new int[clus];

            //DETERMINE WHAT CLUSTER EACH POINT BELONGS TO
            // determine class membership i.e., which point belongs to which cluster
            PList = new List<MyPoint>();
            for (int i = 0; i < X.Rows; i++) //looping throught all the rows = #points of Gamma -- each col = probability for each cluster
            {
                // Gamma matrix has the probabilities for a data point for its membership in each cluster
                double[] probabs = new double[clus];
                int cnum = 0;
                double maxprobab = myGMM.Gamma[i, 0];
                for (int m = 0; m < clus; m++) // Going throught the cols --- each col has probability for one cluster
                {
                    if (myGMM.Gamma[i, m] > maxprobab) //checking for the cluster with more probability
                    {
                        cnum = m;  // data i belongs to cluster m
                        maxprobab = myGMM.Gamma[i, m];
                    }
                }
                MyPoint pnt = new MyPoint(X[i,0], X[i,1], cnum); 
                PList.Add(pnt);
            }
            
            double fValue = FunctionToSolve(Xsi, Ysi, particlesInCLuster);
            return fValue;
        }
    }
}
