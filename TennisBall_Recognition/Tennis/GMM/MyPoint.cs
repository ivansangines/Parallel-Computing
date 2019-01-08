using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMM
{
    //Class used to create points using the pixels from the Image
    //Each point will have 4 attributes: RED, GREEN, BLUE and CLUSTER ID
    public class MyPoint
    {
        public double Red {get; set; }
        public double Green {get; set; }
        public double Blue { get; set; }
        public int ClusterId { get; set; }

        //Constructor used while processing pixels from the Uploaded image
        //clusterid needs default value because when we create points we do not know the cluster yet
        public MyPoint(double red, double green, double blue, int cluster = -1) 
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
            this.ClusterId = cluster;
        }
    }
}
