using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMM
{
    class Particle
    {
        public double W { get; set; } // inertia or weight
        public double C1 { get; set; } // cognitive social const
        public double C2 { get; set; }
        Random ran = new Random();
        // we will be solving a 2-D problem in x and y
        // so there will be two components to velocity and position
        public double[] Xx { get; set; } // poistion in x
        public double[] Xy { get; set; } // position in y
        public double[] Vx { get; set; } // velocity in x
        public double[] Vy { get; set; } // velocity in y
        public List<MyPoint> PositionsSorted;  // sorted list for further updates of positions

        public Particle(int clus)
        {
            Xx = new double[clus];
            Xy = new double[clus];
            Vx = new double[clus];
            Vy = new double[clus];

        }

        public void setPsorted(List<MyPoint> plist)
        {
            PositionsSorted = new List<MyPoint>(plist);
            PositionsSorted.Sort();
        }

        public List<MyPoint> getPsorted()
        {
            return PositionsSorted;
        }

        public void UpdateVelocity(double[] Px, double[] Py, double[] Gx, double[] Gy)
        {
            for (int i=0; i<Xx.Length; i++)
            {
                // P is the current best position of any particle in the swarm
                // G is the global best position discovered so far
                Vx[i] = W * Vx[i] + C1 * ran.NextDouble() * (Px[i] - Xx[i]) +
                C2 * ran.NextDouble() * (Gx[i] - Xx[i]);
                if (Vx[i] > 15)
                    Vx[i] = 15;
                if (Vx[i] < -15)
                    Vx[i] = -15;
                Vy[i] = W * Vy[i] + C1 * ran.NextDouble() * (Py[i] - Xy[i]) +
                C2 * ran.NextDouble() * (Gy[i] - Xy[i]);
                if (Vy[i] > 15)
                    Vy[i] = 15;
                if (Vy[i] < -15)
                    Vy[i] = -15;

            }
            
        }

        public void UpdatePosition()
        {
            for (int i =0; i<Xx.Length; i++) //position particles, one position per cluster
            {
                MyPoint searching = new MyPoint(Xx[i], Xy[i]);

                for (int ind=0; ind<PositionsSorted.Count; ind++)
                {
                    
                    if (((int)searching.X == (int)PositionsSorted[i].X) && ((int)searching.Y == (int)PositionsSorted[i].Y))
                    {
                        int index = ind + (int)Vx[i] + (int)Vy[i];
                        if (index > PositionsSorted.Count)
                        {
                            index = PositionsSorted.Count - 1;
                        }
                        if (index < 0)
                        {
                            index = 0;
                        }
                        //Updating position based on V
                        //Since the list of points is sorted, we move to near point (not random)
                        Xx[i] = PositionsSorted[index].X;
                        Xy[i] = PositionsSorted[index].Y;
                    }
                }

                

            }
            
            /*
            Xx = Xx + Vx;
            // we need to put some bounds on the position
            if (Xx > 20)
                Xx = 20;
            if (Xx < -20)
                Xx = -20;
            Xy = Xy + Vy;
            if (Xy > 20)
                Xy = 20;
            if (Xy < -20)
                Xy = -20;
            */
        }
    }
}
