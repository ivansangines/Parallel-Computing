using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class Form1 : Form
    {
        Bitmap bmpOrig;
        Bitmap bmpProc;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "C:\\Users\\ivans_000\\Desktop\\Fall2018\\PARALLEL\\CS590_SANGINES_HW4";
            if (ofd.ShowDialog() == DialogResult.OK)

            {
                bmpOrig = new Bitmap(ofd.FileName);
                pic1.Image = bmpOrig;
                lblWidth.Text = bmpOrig.Width.ToString();
                lblHeight.Text = bmpOrig.Height.ToString();
            }

        }

        private void btnConvertToGray_Click(object sender, EventArgs e)
        {
            bmpProc = new Bitmap(bmpOrig.Width, bmpOrig.Height);
            object olock = new object();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int width = bmpOrig.Width;
            int height = bmpOrig.Height;
            Parallel.For(0, width, (x) =>
            //for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color currentPixel;
                    lock (olock)
                    {
                        currentPixel = bmpOrig.GetPixel(x, y);
                    }
                    int red = currentPixel.R;
                    int green = currentPixel.G;
                    int blue = currentPixel.B;
                    int gray = (int)(0.299 * red + 0.587 * green + 0.114 * blue);
                    lock (olock)
                    {
                        bmpProc.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                    }
                }
            //}
            });
            sw.Stop();
            pic1.Image = bmpProc;
            MessageBox.Show("Time taken = " + sw.ElapsedMilliseconds.ToString() +
            " milliseconds");
        }

        private void btnConvertToGrayUnsafe_Click(object sender, EventArgs e)
        {
            bmpProc = new Bitmap(bmpOrig);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            unsafe // unsafe block allows direct memory access
            { // like C/C++ pointers
              // Project has to be compiled with unsafe option
                BitmapData bitmapData = bmpProc.LockBits(new Rectangle(0, 0, bmpProc.Width, bmpProc.Height),
                ImageLockMode.ReadWrite, bmpProc.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bmpProc.PixelFormat) / 8;
                int height = bmpProc.Height;
                int widthinBytes = bitmapData.Width * bytesPerPixel;
                byte* ptr = (byte*)bitmapData.Scan0; // point to the first pixel
                for (int y = 0; y < height; y++)
                {
                    byte* currentLine = ptr + (y * bitmapData.Stride);
                    for (int x = 0; x < widthinBytes; x = x + bytesPerPixel)
                        
                {
                        int blue = currentLine[x];
                        int green = currentLine[x + 1];
                        int red = currentLine[x + 2];
                        int gray = (int)(0.299 * red + 0.587 * green + 0.114 * blue);
                        currentLine[x] = (byte)gray;
                        currentLine[x + 1] = (byte)gray;
                        currentLine[x + 2] = (byte)gray;
                    }
                }
                bmpProc.UnlockBits(bitmapData);
            } // end of unsafe
            sw.Stop();
            pic1.Image = bmpProc;
            MessageBox.Show("Time taken = " + sw.ElapsedMilliseconds.ToString());
        }

        private void btnConvertToGrayParalle_Click(object sender, EventArgs e)
        {
            bmpProc = new Bitmap(bmpOrig);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            unsafe // unsafe block allows direct memory access
            { // like C/C++ pointers
              // Project has to be compiled with unsafe option
                BitmapData bitmapData =
                bmpProc.LockBits(new Rectangle(0, 0, bmpProc.Width,
               bmpProc.Height),
                ImageLockMode.ReadWrite, bmpProc.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bmpProc.PixelFormat) / 8;
                int height = bmpProc.Height;
                int widthinBytes = bitmapData.Width * bytesPerPixel;
                byte* ptr = (byte*)bitmapData.Scan0; // point to the first pixel
                Parallel.For(0, height, (y) =>
                //for (int y = 0; y < height; y++)
                {
                    byte* currentLine = ptr + (y * bitmapData.Stride);
                    
                for (int x = 0; x < widthinBytes; x = x + bytesPerPixel)
                    {
                        int blue = currentLine[x];
                        int green = currentLine[x + 1];
                        int red = currentLine[x + 2];
                        int gray = (int)(0.299 * red + 0.587 * green + 0.114 * blue);
                        currentLine[x] = (byte)gray;
                        currentLine[x + 1] = (byte)gray;
                        currentLine[x + 2] = (byte)gray;
                    }
                });
                bmpProc.UnlockBits(bitmapData);
            } // end of unsafe
            sw.Stop();
            pic1.Image = bmpProc;
            MessageBox.Show("Time taken = " + sw.ElapsedMilliseconds.ToString());

        }
    }
}
