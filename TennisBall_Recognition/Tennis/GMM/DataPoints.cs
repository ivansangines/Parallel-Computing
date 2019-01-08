using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMM
{
    class DataPoints
    {
        public Bitmap MyBit { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public DataPoints(Bitmap bit, double width, double height)
        {
            this.MyBit = bit;
            this.Width = width;
            this.Height = height;
        }

        public List<MyPoint> CreatePoints()
        {
            List<MyPoint> myList = new List<MyPoint>();
            for (int rw = 0; rw<(this.Width); rw++) //moving through rows of pixels from bitmap
            {
                for (int col = 0; col < (this.Height); col++) //moving thought cols of pixels from bitmap
                {
                    Color pixels = this.MyBit.GetPixel(rw, col);
                    int red = pixels.R;
                    int green = pixels.G;
                    int blue = pixels.B;
                    MyPoint point = new MyPoint(red, green, blue);
                    myList.Add(point);
                }
            }

            return myList;
        }
    }
}
