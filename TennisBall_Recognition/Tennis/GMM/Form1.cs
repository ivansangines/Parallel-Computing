using Mapack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMM
{
    public partial class Form1 : Form
    {
        /*
        double[] mu = null;  // mean for cluster k
        Random rand = new Random();
        double[] sigma = null;  // standard dev for cluster k
        double[,] pdf = null;   // calculated pdf for each data point based on mean and var for cluster k
        double[,] Gamma = null; // probablity matrix for each data point
                                // i.e., probablity that a data point belongs to cluster i
        double[] phi = null;    // prior probabilities for each cluster
        */

        Bitmap picture; //I will create a Bitmap with the image uploaded to extract pixels
        Bitmap uni_Cluster; //Bitmap use to show the cluster clicked (just one cluster showing
        GMM_NDim myGmm; //GMM that we will use in order to process clusters based on image pixels
        List<MyPoint> PList; //List will all points
        DataPoints data; //Object of the class DataPoints where we delegate the work to extract points from image
        Matrix X; //Matrix cols= R, B, G values --- Matrix rows = Size of data
        int k = 4; // number of clusters
        int dimenssions = 3; // I will use 3 dimenssions: R,G,B
        int data_Size = 0; //Size of the data, it will be calculated with our pic1 height and width
        bool uploaded = false; //check if the image is uploaded
        bool computed = false;
        
    
        public Form1()
        {
            InitializeComponent();
        }

        //UPLOADING IMAGE
        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog myFile = new OpenFileDialog();
                myFile.InitialDirectory = "C:\\Users\\ivans_000\\Desktop\\Fall2018\\PARALLEL\\MIDTERM_SANGINES\\TennisImages";
                myFile.Multiselect = false; //just one file can be uploaded
                if (myFile.ShowDialog() == DialogResult.OK) //We need to check before initializing
                {
                    picture = new Bitmap(myFile.FileName); //creating a Bitmap with image uploaded
                                                          
                }
                while (picture.Width > pic1.Width || picture.Height > pic1.Height) //Resize image to fit in pictureBox                
                    picture = new Bitmap(picture, (int)(Convert.ToInt32(picture.Width) / 1.5), (int)(Convert.ToInt32(picture.Height) / 1.5) );
                    //picture.Size = new Size(picture.Height / 2, picture.Width / 2); read only
                
                pic1.Image = picture;
                data_Size = picture.Width * picture.Height;
                uploaded = true;
                

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        //CREATING CLUSTERS AND SHOWING MEANS FOR EACH CLUSTER
        private void btnCompute_Click(object sender, EventArgs e)
        {
            if(uploaded == true)
            {
                Stopwatch sw = new Stopwatch();
                
                try
                {
                    k = int.Parse(txtClusters.Text); //getting number of clusters
                }
                catch
                {
                    MessageBox.Show("Wrong input.");
                }

                
                //sw.Start();
                data = new DataPoints(picture, picture.Width, picture.Height);
                PList = new List<MyPoint>(data.CreatePoints());
                X = new Matrix(data_Size, dimenssions);
                for (int i=0; i < PList.Count; i++)
                {
                    X[i, 0] = PList[i].Red;
                    X[i, 1] = PList[i].Green;
                    X[i, 2] = PList[i].Blue;
                }

                myGmm = new GMM_NDim(k, dimenssions, X);
                sw.Start();
                myGmm.ComputeGMM_ND();
                sw.Stop();
                MessageBox.Show("Time elapsed in ms: " + sw.ElapsedMilliseconds);

                // determine class membership i.e., which point belongs to which cluster
                PList = new List<MyPoint>();
                for (int i = 0; i < X.Rows; i++) //looping throught all the rows = #points of Gamma -- each col = probability for each cluster
                {
                    // Gamma matrix has the probabilities for a data point for its membership in each cluster
                    double[] probabs = new double[k];
                    int cnum = 0;
                    double maxprobab = myGmm.Gamma[i, 0];
                    for (int m = 0; m < k; m++) // Going throught the cols --- each col has probability for one cluster
                    {
                        if (myGmm.Gamma[i, m] > maxprobab) //checking for the cluster with more probability
                        {
                            cnum = m;  // data i belongs to cluster m
                            maxprobab = myGmm.Gamma[i, m];
                        }
                    }
                    MyPoint pt = new MyPoint (X[i,0], X[i,1], X[i,2], cnum); //X[i,0] = RED X[i,1] = GREEN X[i,2] = BLUE
                    PList.Add(pt);
                }

                computed = true;
                showMeans();


            }
            else
            {
                MessageBox.Show("You need to upload an image first.");
            }
        }

        //METHOD THAT WILL GO OVER mu AND CREATE AN OUTPUT WITH THE mu FOR R,G,B OF EACH CLUSTER
        void showMeans()
        {
            string output = "";
            for(int clus = 0; clus < k; clus++) //creating a output with means of red, green, blue for each cluster
            {
                output += "Cluster"+ (clus+1) + "\r\n";
                output += "Red mean = " + (int)(myGmm.mu[clus][0, 0]) + "\r\n" +
                          "Green mean = " + (int)(myGmm.mu[clus][0, 1]) + "\r\n" +
                          "Blue mean = " + (int)(myGmm.mu[clus][0, 2]) + "\r\n \r\n";
            }

            txtResult.Text = output;

        }

        //METHOD WHICH WILL SET TO WHITE ALL THE PIXELS BUT THE ONES FROM THE CLUSTER INDICATED
        void uniqueCluster(int number)
        {
            uni_Cluster = new Bitmap(picture);
            int position = 0;
            for(int i = 0; i < picture.Width; i++)
            {
                for(int j = 0; j < picture.Height; j++)
                {
                    if (PList[position].ClusterId != number)
                        uni_Cluster.SetPixel(i, j, Color.White);
                    position++;
                }
            }

            pic1.Image = uni_Cluster; //image will keep the indicated cluster with color and the rest will be white 

        }

        //ONCE THE CLUSTER IS INDICATED, IT WILL CALL TO uniqueCluster AND SHOW JUST THE SPECIFIED CLUSTER
        private void btnUnique_Click(object sender, EventArgs e)
        {
            if (computed)
            {
                try
                {
                    int cNum = int.Parse(txtChoosen.Text);
                    if (cNum < 1 || cNum > 4)
                    {
                        MessageBox.Show("You must choose between 1 and 4.");
                    }
                    else
                    {
                        uniqueCluster((cNum -1));
                    }
                }
                catch
                {
                    MessageBox.Show("Wrong input.");
                }
            }
            else
            {
                MessageBox.Show("You must Compute an image first.");
            }
        }

        //SETS THE IMAGE BACK TO ORIGINAL
        private void btnOriginal_Click(object sender, EventArgs e)
        {
            if (uploaded)
                pic1.Image = picture;
            else
                MessageBox.Show("You must upload an image.");
        }

        private void pic1_Click(object sender, EventArgs e)
        {
            if (uploaded)
            {
                MouseEventArgs clicked = (MouseEventArgs)e;
                if(clicked.X<0 || clicked.X>picture.Width || clicked.Y<0 || clicked.Y > picture.Height)                
                    MessageBox.Show("You did not click the image");
                else
                {
                    int position = (clicked.X * picture.Height) + clicked.Y; // Multiply by height because it is inner loop for data initialization
                                                                             // All the pixels (0,i) beeing i height are added first. 
                                                                             // Then we will add (1,i) having height number of pixels processed before 
                                                                             //That is why we need to X*Height --- For each X we have Height # of pixels/points before
                    int clusterClicked = PList[position].ClusterId;
                    uniqueCluster(clusterClicked);
                }
                

            }
            else
            {
                MessageBox.Show("You must upload a Picture first.");
            }
        }
    }
}
