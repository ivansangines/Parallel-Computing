﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KMeansClustering
{
    class KMeans
    {
        public static int DoKMeansWithMinVariance(int numClusters, ref List<MyPoint> PList, ref List<ClusterCenterPoint> CList, double maxError, int maxIterations, bool minVariance)
        {
            List<MyPoint> copy = new List<MyPoint>(PList);
            object olock = new object();

            double stddev = 0;
            if (minVariance == true)
                stddev = double.MaxValue;
            else
                stddev = double.MinValue;

            List<MyPoint> PListBest = new List<MyPoint>();
            List<ClusterCenterPoint> CListBest = new List<ClusterCenterPoint>();
            int iter = 0;

            Parallel.For(0, 20, (m) =>
            //for (int m = 0; m < 20; m++) //Pick best (most balanced) clustering after 20 clustering attempts
            {
                List<MyPoint> PListCopy = new List<MyPoint>();
                for (int i = 0; i < copy.Count; i++)
                    PListCopy.Add((MyPoint)copy[i].Clone());
                //foreach (MyPoint mp in PList)
                    //PListCopy.Add((MyPoint)mp.Clone());
                List<ClusterCenterPoint> CListCopy = null;
                iter += KMeans.DoKMeans(numClusters, ref PListCopy, ref CListCopy, 0.01, 100, true); // true means do kmeansplusplus
                                                                                                     // ----compute variance of cluster memberships
                int[] CCount = new int[numClusters];
                for (int i = 0; i < numClusters; i++)
                    CCount[i] = 0;
                foreach (MyPoint mp in PListCopy)
                    CCount[mp.ClusterId] += 1;

                double variance = 0;
                for (int i = 0; i < numClusters; i++)
                    variance += (CCount[i] - (PListCopy.Count) / (double)numClusters) * (CCount[i] - (PListCopy.Count) / (double)numClusters);
                double stddevCopy = Math.Sqrt(variance);
                string out1 = "";
                for (int n = 0; n < CCount.Length; n++)
                    out1 += "Cluster " + n.ToString() + " count = " + CCount[n].ToString() + "\n";
                //MessageBox.Show("StdDev = " + stddevCopy.ToString() + " " + out1);
                if (minVariance == true)
                {
                    lock (olock) //Protect while updating stddev. 
                                 // Otherwise one thread X can obtain a X stddevcopy better than the actual one stop at the if validation
                                 //then a new thread Y starts with Y stddevcopy better than actual one and X one, updates stddev and stops
                                 //thread X starts again (does not need to pass if statement again) and updates stddevcopy which would be wrong since the best one was Y

                    {
                        if (stddevCopy < stddev) // if it improves, copy data into best
                        {
                            stddev = stddevCopy;
                            PListBest.Clear();
                            foreach (MyPoint mp in PListCopy)
                                PListBest.Add((MyPoint)mp.Clone());
                            CListBest.Clear();
                            foreach (ClusterCenterPoint cp in CListCopy)
                                CListBest.Add((ClusterCenterPoint)cp.Clone());
                        }
                    }
                }
                /*
                else
                {
                    lock (olock)
                    {
                        if (stddevCopy > stddev) // if it improves, copy data into best
                        {
                            stddev = stddevCopy;
                            PListBest.Clear();
                            foreach (MyPoint mp in PListCopy)
                                PListBest.Add((MyPoint)mp.Clone());
                            CListBest.Clear();
                            foreach (ClusterCenterPoint cp in CListCopy)
                                CListBest.Add((ClusterCenterPoint)cp.Clone());
                        }
                    }
                }
                */
            });
            CList = CListBest;
            PList = PListBest;
            return iter;

        }

        public static int DoKMeans(int numClusters, ref List<MyPoint> PList, ref List<ClusterCenterPoint> CL, double maxError, int maxIterations, bool doKmeansPlusPlus = false)
        {
            List<ClusterCenterPoint> CList = null;
            if (doKmeansPlusPlus == false)
                InitializeCentersRandomlyFromGivenPoints(PList, ref CList, numClusters);
            else
                InitializeCentersRandomlyFromKPP(PList, ref CList, numClusters);
            double error = double.MaxValue;
            int iteration = 0;
            while ((iteration < maxIterations) || (error < maxError))
            {
                // determine which clusetr each point belongs to
                foreach (MyPoint p in PList)
                {
                    // determine which cluster it belongs to
                    int k = 0;
                    double prevDist = double.MaxValue;
                    foreach (ClusterCenterPoint cp in CList)
                    {
                        double dist = FindDistance(p.X, p.Y, cp.Cx, cp.Cy);
                        if (dist < prevDist)
                        {
                            prevDist = dist;
                            p.ClusterId = k;
                        }
                        k++;
                    }
                }
                /*
                int c0count = (from p in PList where p.ClusterId == 0 select p).ToList<MyPoint>().Count;
                int c1count = (from p in PList where p.ClusterId == 1 select p).ToList<MyPoint>().Count;
                int c2count = (from p in PList where p.ClusterId == 2 select p).ToList<MyPoint>().Count;
                */

                // ---------------Recompute cluster centers-------------------
                List<ClusterCenterPoint> CListNew = new List<ClusterCenterPoint>();
                int[] CCount = new int[CList.Count];
                foreach (ClusterCenterPoint cp in CList)
                {
                    ClusterCenterPoint cpnew = new ClusterCenterPoint();
                    CListNew.Add(cpnew);
                    cpnew.Cx = 0;
                    cpnew.Cy = 0;
                }
                foreach (MyPoint p in PList)
                {
                    CListNew[p.ClusterId].Cx += p.X;
                    CListNew[p.ClusterId].Cy += p.Y;
                    CCount[p.ClusterId]++;
                }
                int knew = 0;
                foreach (ClusterCenterPoint cp in CListNew)
                {
                    cp.Cx = cp.Cx / CCount[knew];
                    cp.Cy = cp.Cy / CCount[knew];
                    knew++;
                }
                //------------------end recompute cluster centers-----------------
                //---------------see if new centers are different from previous---
                double err = 0;
                for (int i = 0; i < CList.Count; i++)
                    err = err + ((CListNew[i].Cx - CList[i].Cx) * (CListNew[i].Cx - CList[i].Cx) + (CListNew[i].Cy - CList[i].Cy) * (CListNew[i].Cy - CList[i].Cy));
                if (err < maxError)
                    break;
                CList.Clear();
                CList = CListNew;
                iteration++;
            }
            CL = CList;
            return iteration;
        }

        public static void InitializeCentersRandomlyBetweenMaxMinRanges(List<MyPoint> PList, ref List<ClusterCenterPoint> CList, int numClusters)
        {
            // determine ranges
            double minX = (from p in PList select p.X).Min();
            double minY = (from p in PList select p.Y).Min();
            double maxX = (from p in PList select p.X).Max();
            double maxY = (from p in PList select p.X).Max();
            // initialize cluster centers randomly
            Random rand = new Random((int)DateTime.Now.Ticks);
            CList = new List<ClusterCenterPoint>();
            for (int i = 0; i < numClusters; i++)
            {
                //ClusterCenterPoint cp = new ClusterCenterPoint { Cx = rand.NextDouble()*(maxX - minX), Cy = rand.NextDouble() * (maxY - minY) };
                int num = (int)rand.NextDouble() * PList.Count;
                ClusterCenterPoint cp = new ClusterCenterPoint { Cx = PList[num].X, Cy = PList[num].Y };
                cp.ClusterID = i;
                CList.Add(cp);
            }
        }

        public static void InitializeCentersRandomlyFromGivenPoints(List<MyPoint> PList, ref List<ClusterCenterPoint> CList, int numClusters)
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            CList = new List<ClusterCenterPoint>();
            List<int> PListInt = new List<int>();
            for (int i = 0; i < PList.Count; i++)
                PListInt.Add(i);
            for (int i = 0; i < numClusters; i++)
            {
                int num = rand.Next(PListInt.Count);
                ClusterCenterPoint cp = new ClusterCenterPoint
                {
                    Cx = PList[num].X,
                    Cy = PList[num].Y
                };
                cp.ClusterID = i;
                PListInt.RemoveAt(num); // remove the number that has been selected so that it does not get selected again
                CList.Add(cp);
            }
            if (CList.Count < numClusters)
                throw new Exception("problem in initializing cluster centers..");
        }

        public static void InitializeCentersRandomlyFromKPP(List<MyPoint> PList, ref List<ClusterCenterPoint> CList, int numClusters)
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            CList = new List<ClusterCenterPoint>();
            List<int> PListInt = new List<int>();
            for (int i = 0; i < PList.Count; i++)
                PListInt.Add(i);

            //step1: of KPP - choose a center randomly from given set of points
            int num = rand.Next(PListInt.Count);
            ClusterCenterPoint cp = new ClusterCenterPoint
            {
                Cx = PList[num].X,
                Cy = PList[num].Y
            };
            cp.ClusterID = 0;
            PListInt.RemoveAt(num); // remove the number that has been selected so that it does not get selected again
            CList.Add(cp);
            for (int i = 1; i < numClusters; i++)
            {
                // Step2: Compute D(x)^2 where D(x) is the distance of x from closest centers chosen
                double dxSquared = 0;
                double[] dxprimeSquared = new double[PListInt.Count];
                for (int m = 0; m < PListInt.Count; m++)
                {
                    double distprev = double.MaxValue;
                    foreach (ClusterCenterPoint ccp in CList)
                    {
                        double dist = FindDistance(PList[PListInt[m]].X, PList[PListInt[m]].Y, ccp.Cx, ccp.Cy);
                        if (dist < distprev)
                        {
                            distprev = dist;
                        }
                    }
                    //dxprimeSquared[PListInt[m]] = distprev * distprev;
                    dxprimeSquared[m] = distprev * distprev; // dxprimesquared value is actually for point PListInt[m]                    
                    dxSquared += distprev * distprev;
                }

                // select the center according to probability d(x')^2/(d()^2
                double randNum = rand.NextDouble();
                double sumProbab = 0;
                for (int n = 0; n < dxprimeSquared.Length; n++)
                {
                    sumProbab = sumProbab + dxprimeSquared[n] / dxSquared;
                    if (randNum <= sumProbab)
                    { // choose this PList[PListInt[n]] as the next cluster center
                        ClusterCenterPoint cpp = new ClusterCenterPoint
                        {
                            Cx = PList[PListInt[n]].X,
                            Cy = PList[PListInt[n]].Y
                        };
                        cpp.ClusterID = i;
                        PListInt.RemoveAt(n); // remove the number that has been selected so that it does not get selected again
                        CList.Add(cpp);
                        break;
                    }
                }
            }
        }

        public static double FindDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }

    }    

}


