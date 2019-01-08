namespace KMedoidsClustering
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
            this.btnKMedoid = new System.Windows.Forms.Button();
            this.btnRedraw = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtClusters = new System.Windows.Forms.TextBox();
            this.pic1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 27);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load Data Points";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnInitialize
            // 
            this.btnInitialize.Location = new System.Drawing.Point(12, 68);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(100, 23);
            this.btnInitialize.TabIndex = 1;
            this.btnInitialize.Text = "Initialize Data";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // btnKMedoid
            // 
            this.btnKMedoid.Location = new System.Drawing.Point(12, 181);
            this.btnKMedoid.Name = "btnKMedoid";
            this.btnKMedoid.Size = new System.Drawing.Size(100, 23);
            this.btnKMedoid.TabIndex = 2;
            this.btnKMedoid.Text = "KMedoid";
            this.btnKMedoid.UseVisualStyleBackColor = true;
            this.btnKMedoid.Click += new System.EventHandler(this.btnKMedoid_Click);
            // 
            // btnRedraw
            // 
            this.btnRedraw.Location = new System.Drawing.Point(390, 415);
            this.btnRedraw.Name = "btnRedraw";
            this.btnRedraw.Size = new System.Drawing.Size(95, 23);
            this.btnRedraw.TabIndex = 3;
            this.btnRedraw.Text = "Redraw Clusters";
            this.btnRedraw.UseVisualStyleBackColor = true;
            this.btnRedraw.Click += new System.EventHandler(this.btnRedraw_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "K:";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(12, 227);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(100, 179);
            this.txtResult.TabIndex = 5;
            // 
            // txtClusters
            // 
            this.txtClusters.Location = new System.Drawing.Point(79, 144);
            this.txtClusters.Name = "txtClusters";
            this.txtClusters.Size = new System.Drawing.Size(33, 20);
            this.txtClusters.TabIndex = 6;
            // 
            // pic1
            // 
            this.pic1.Location = new System.Drawing.Point(139, 12);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(636, 450);
            this.pic1.TabIndex = 7;
            this.pic1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pic1);
            this.Controls.Add(this.txtClusters);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRedraw);
            this.Controls.Add(this.btnKMedoid);
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
        private System.Windows.Forms.Button btnKMedoid;
        private System.Windows.Forms.Button btnRedraw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtClusters;
        private System.Windows.Forms.PictureBox pic1;
    }
}

