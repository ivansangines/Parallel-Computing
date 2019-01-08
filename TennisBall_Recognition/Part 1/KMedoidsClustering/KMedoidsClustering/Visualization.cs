﻿using System;
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
        public static bool DrawPoints(PictureBox pan, List<Point> PList, double scale)
        {
            Graphics dc = pan.CreateGraphics();

            for (int i=0; i<PList.Count; i++)
            {
                Point p = (Point)PList[i];
                Point pa = new Point((int)(p.X * scale) - 2, (int)(p.Y * scale) - 2);
                Point pb = new Point((int)(p.X * scale) + 2, (int)(p.Y * scale) + 2);
                dc.DrawLine(new Pen(Color.Red), pa, pb); //First line of the X

                Point pa2 = new Point((int)(p.X * scale) + 2, (int)(p.Y * scale) - 2);
                Point pb2 = new Point((int)(p.X * scale) - 2, (int)(p.Y * scale) + 2);
                dc.DrawLine(new Pen(Color.Red), pa2, pb2); //Second line of the X 
            }

            return true;           

        }
        

        public static bool DrawClusters(PictureBox pan, List<Point> PList, List<int> clusterInfo, int clusterCount, int[] medoids, double scale = 1)
        {
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
            Brush br = new SolidBrush(Color.Red);
            Point p1 = (Point)PList[0];
            Point p1a = new Point((int)(p1.X * scale) - 2, (int)(p1.Y * scale) - 2);
            Point p2a = new Point((int)(p1.X * scale) + 2, (int)(p1.Y * scale) + 2);
            dc.DrawLine(new Pen(CColors[clusterInfo[0]], 1), p1a, p2a);
            Point p3a = new Point((int)(p1.X * scale) + 2, (int)(p1.Y * scale) - 2);
            Point p4a = new Point((int)(p1.X * scale) - 2, (int)(p1.Y * scale) + 2);
            dc.DrawLine(new Pen(CColors[clusterInfo[0]], 1), p3a, p4a);
            Point pstart = new Point(p1.X, p1.Y);
            Point p2;
            for (int i = 1; i < PList.Count; i++)
            {
                if (medoids.Contains<int>(i))
                {
                    p2 = (Point)PList[i];
                    dc.DrawEllipse(new Pen(CColors[clusterInfo[i]], 1), (int)(p2.X * scale) - 2, (int)(p2.Y * scale) - 2, 4, 4);
                }
                else
                {
                    p2 = (Point)PList[i];
                    p1a = new Point((int)(p2.X * scale) - 2, (int)(p2.Y * scale) - 2);
                    p2a = new Point((int)(p2.X * scale) + 2, (int)(p2.Y * scale) + 2);
                    dc.DrawLine(new Pen(CColors[clusterInfo[i]], 1), p1a, p2a);
                    p3a = new Point((int)(p2.X * scale) + 2, (int)(p2.Y * scale) - 2);
                    p4a = new Point((int)(p2.X * scale) - 2, (int)(p2.Y * scale) + 2);
                    dc.DrawLine(new Pen(CColors[clusterInfo[i]]), p3a, p4a);
                }
            }
            return true;
        }

    }

}
