using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KMedoidsClustering
{
    class Visualization
    {
        public static bool DrawPoints(PictureBox pan, List<Point> list, double scale = 1)
        {
            
            Graphics dc = pan.CreateGraphics();
            dc.Clear(Color.White);
            object olock = new object();


            Parallel.For(0, list.Count, (i) =>
             {
                 Point p1 = (Point)list[i];
                 lock (olock)
                 {
                     Point p1a = new Point((int)(p1.X * scale) - 2, (int)(p1.Y * scale) - 2);
                     Point p2a = new Point((int)(p1.X * scale) + 2, (int)(p1.Y * scale) + 2);
                     dc.DrawLine(new Pen(Color.Red, 1), p1a, p2a); //First line of X
                 }

                 lock (olock)
                 {
                     Point p3a = new Point((int)(p1.X * scale) + 2, (int)(p1.Y * scale) - 2);
                     Point p4a = new Point((int)(p1.X * scale) - 2, (int)(p1.Y * scale) + 2);
                     dc.DrawLine(new Pen(Color.Red, 1), p3a, p4a); //Second line of X
                 }
            });

            return true;
        }

        public static bool DrawClusters(PictureBox pan, List<Point> PList, List<int> clusterInfo, int clusterCount, int[] medoids, double scale = 1)
        {
            object olock = new object();
            // set cluster colors
            Color[] CColors = new Color[clusterCount];
            for (int i = 0; i < clusterCount; i++)
            {
                if (i == 0)
                    CColors[i] = Color.Red;
                else if (i == 1)
                    CColors[i] = Color.Green;
                else if (i == 2)
                    CColors[i] = Color.Purple;
                else if (i == 3)
                    CColors[i] = Color.Aqua;
                else if (i == 4)
                    CColors[i] = Color.Black;
                else if (i == 5)
                    CColors[i] = Color.Orange;
                else if (i == 6)
                    CColors[i] = Color.Salmon;
                else if (i == 7)
                    CColors[i] = Color.Yellow;
                else if (i == 8)
                    CColors[i] = Color.Pink;
                else if (i == 9)
                    CColors[i] = Color.LightBlue;
                else if (i == 10)
                    CColors[i] = Color.Lavender;
                else if (i == 11)
                    CColors[i] = Color.LightGreen;
                else if (i == 12)
                    CColors[i] = Color.LightSeaGreen;
                else if (i == 13)
                    CColors[i] = Color.LightSteelBlue;
                else if (i == 14)
                    CColors[i] = Color.Lime;
                else if (i == 15)
                    CColors[i] = Color.Magenta;
                else if (i == 16)
                    CColors[i] = Color.MediumAquamarine;
                else if (i == 17)
                    CColors[i] = Color.PaleVioletRed;
                else if (i == 18)
                    CColors[i] = Color.Firebrick;
                else if (i == 19)
                    CColors[i] = Color.DodgerBlue;
                else if (i == 20)
                    CColors[i] = Color.HotPink;
                else if (i == 21)
                    CColors[i] = Color.Orchid;
                else if (i == 22)
                    CColors[i] = Color.Sienna;
                else if (i == 23)
                    CColors[i] = Color.Turquoise;
                else if (i == 24)
                    CColors[i] = Color.YellowGreen;
                else if (i == 25)
                    CColors[i] = Color.Tomato;
                else if (i == 26)
                    CColors[i] = Color.Indigo;
                else if (i == 27)
                    CColors[i] = Color.PaleVioletRed;
                else if (i == 28)
                    CColors[i] = Color.Peru;
                else if (i == 29)
                    CColors[i] = Color.Plum;
                else if ((i % 2) == 0)
                    CColors[i] = Color.FromArgb(255, 180 - (i * 2), 100 + (i * 2));
                else
                    CColors[i] = Color.FromArgb(100 + i * 2, 180 - (i * 2), 255);
            }

            Graphics dc = pan.CreateGraphics();
            dc.Clear(Color.White);

            Parallel.For(0, PList.Count, (i) =>
             {
                 Point p1 = (Point)PList[i];
                 if (medoids.Contains<int>(i))
                 {
                     lock (olock)
                     {
                         p1 = (Point)PList[i];
                         dc.DrawEllipse(new Pen(Color.Black, 1), (int)(p1.X * scale) - 2, (int)(p1.Y * scale) - 2, 4, 4);
                     }
                 }
                 else
                 {
                     lock (olock)
                     {
                         Point p1a = new Point((int)(p1.X * scale) - 2, (int)(p1.Y * scale) - 2);
                         Point p2a = new Point((int)(p1.X * scale) + 2, (int)(p1.Y * scale) + 2);
                         dc.DrawLine(new Pen(CColors[clusterInfo[i]], 1), p1a, p2a);
                     }

                     lock (olock)
                     {

                         Point p3a = new Point((int)(p1.X * scale) + 2, (int)(p1.Y * scale) - 2);
                         Point p4a = new Point((int)(p1.X * scale) - 2, (int)(p1.Y * scale) + 2);
                         dc.DrawLine(new Pen(CColors[clusterInfo[i]]), p3a, p4a);
                     }
                 }
                 
             });
            
            return true;
        }

    }

}
