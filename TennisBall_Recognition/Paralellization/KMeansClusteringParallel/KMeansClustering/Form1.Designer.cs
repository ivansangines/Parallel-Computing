namespace KMeansClustering
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnInitialize = new System.Windows.Forms.Button();
            this.btnKmeans = new System.Windows.Forms.Button();
            this.btnKMeansClustering = new System.Windows.Forms.Button();
            this.btnKMeansVariance = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClusters = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.pic1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(121, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load Data File";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnInitialize
            // 
            this.btnInitialize.Location = new System.Drawing.Point(12, 52);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(121, 23);
            this.btnInitialize.TabIndex = 1;
            this.btnInitialize.Text = "Initialize Data";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // btnKmeans
            // 
            this.btnKmeans.Location = new System.Drawing.Point(12, 117);
            this.btnKmeans.Name = "btnKmeans";
            this.btnKmeans.Size = new System.Drawing.Size(121, 23);
            this.btnKmeans.TabIndex = 2;
            this.btnKmeans.Text = "Do KMeans";
            this.btnKmeans.UseVisualStyleBackColor = true;
            this.btnKmeans.Click += new System.EventHandler(this.btnKmeans_Click);
            // 
            // btnKMeansClustering
            // 
            this.btnKMeansClustering.Location = new System.Drawing.Point(12, 155);
            this.btnKMeansClustering.Name = "btnKMeansClustering";
            this.btnKMeansClustering.Size = new System.Drawing.Size(121, 35);
            this.btnKMeansClustering.TabIndex = 3;
            this.btnKMeansClustering.Text = "Do KMeans ++ Clustering";
            this.btnKMeansClustering.UseVisualStyleBackColor = true;
            this.btnKMeansClustering.Click += new System.EventHandler(this.btnKMeansClustering_Click);
            // 
            // btnKMeansVariance
            // 
            this.btnKMeansVariance.Location = new System.Drawing.Point(12, 196);
            this.btnKMeansVariance.Name = "btnKMeansVariance";
            this.btnKMeansVariance.Size = new System.Drawing.Size(121, 44);
            this.btnKMeansVariance.TabIndex = 4;
            this.btnKMeansVariance.Text = "Do Kmeans ++ with Min Variance";
            this.btnKMeansVariance.UseVisualStyleBackColor = true;
            this.btnKMeansVariance.Click += new System.EventHandler(this.btnKMeansVariance_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Num of Clusters";
            // 
            // txtClusters
            // 
            this.txtClusters.Location = new System.Drawing.Point(99, 81);
            this.txtClusters.Name = "txtClusters";
            this.txtClusters.Size = new System.Drawing.Size(34, 20);
            this.txtClusters.TabIndex = 6;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(12, 246);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(121, 177);
            this.txtResult.TabIndex = 7;
            // 
            // pic1
            // 
            this.pic1.Location = new System.Drawing.Point(166, 12);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(730, 505);
            this.pic1.TabIndex = 8;
            this.pic1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 515);
            this.Controls.Add(this.pic1);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtClusters);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKMeansVariance);
            this.Controls.Add(this.btnKMeansClustering);
            this.Controls.Add(this.btnKmeans);
            this.Controls.Add(this.btnInitialize);
            this.Controls.Add(this.btnLoad);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnInitialize;
        private System.Windows.Forms.Button btnKmeans;
        private System.Windows.Forms.Button btnKMeansClustering;
        private System.Windows.Forms.Button btnKMeansVariance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClusters;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.PictureBox pic1;
    }
}

