using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMM
{
    public class MyPoint : IComparable<MyPoint>
    {
        public int ClusterId { get; set; }
        public double X {get; set; }
        public double Y {get; set; }

        public MyPoint()
        {
            this.ClusterId = -1;
            this.X = 0;
            this.Y = 0;
        }
        public MyPoint(double x, double y, int clus = -2)
        {
            this.X = x;
            this.Y = y;
            this.ClusterId = clus;
        }

        public int CompareTo(MyPoint other)
        {
            return (this.X + this.Y).CompareTo((other.X+this.Y));
        }
    }
}
