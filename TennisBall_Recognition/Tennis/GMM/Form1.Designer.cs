namespace GMM
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
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnCompute = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClusters = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.btnOriginal = new System.Windows.Forms.Button();
            this.btnUnique = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtChoosen = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(31, 30);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(126, 23);
            this.btnUpload.TabIndex = 0;
            this.btnUpload.Text = "Upload Image";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnCompute
            // 
            this.btnCompute.Location = new System.Drawing.Point(31, 120);
            this.btnCompute.Name = "btnCompute";
            this.btnCompute.Size = new System.Drawing.Size(126, 23);
            this.btnCompute.TabIndex = 1;
            this.btnCompute.Text = "Compute Clusters";
            this.btnCompute.UseVisualStyleBackColor = true;
            this.btnCompute.Click += new System.EventHandler(this.btnCompute_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of Clusters";
            // 
            // txtClusters
            // 
            this.txtClusters.Location = new System.Drawing.Point(130, 79);
            this.txtClusters.Name = "txtClusters";
            this.txtClusters.Size = new System.Drawing.Size(27, 20);
            this.txtClusters.TabIndex = 3;
            this.txtClusters.Text = "4";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(31, 149);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(126, 285);
            this.txtResult.TabIndex = 4;
            // 
            // pic1
            // 
            this.pic1.Location = new System.Drawing.Point(193, 30);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(582, 392);
            this.pic1.TabIndex = 5;
            this.pic1.TabStop = false;
            this.pic1.Click += new System.EventHandler(this.pic1_Click);
            // 
            // btnOriginal
            // 
            this.btnOriginal.Location = new System.Drawing.Point(31, 440);
            this.btnOriginal.Name = "btnOriginal";
            this.btnOriginal.Size = new System.Drawing.Size(126, 23);
            this.btnOriginal.TabIndex = 6;
            this.btnOriginal.Text = "Show Initial Picture";
            this.btnOriginal.UseVisualStyleBackColor = true;
            this.btnOriginal.Click += new System.EventHandler(this.btnOriginal_Click);
            // 
            // btnUnique
            // 
            this.btnUnique.Location = new System.Drawing.Point(476, 440);
            this.btnUnique.Name = "btnUnique";
            this.btnUnique.Size = new System.Drawing.Size(132, 23);
            this.btnUnique.TabIndex = 7;
            this.btnUnique.Text = "Show Choosen Cluster";
            this.btnUnique.UseVisualStyleBackColor = true;
            this.btnUnique.Click += new System.EventHandler(this.btnUnique_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(28, 450);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(329, 440);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Choose cluster 1-4:";
            // 
            // txtChoosen
            // 
            this.txtChoosen.Location = new System.Drawing.Point(442, 440);
            this.txtChoosen.Name = "txtChoosen";
            this.txtChoosen.Size = new System.Drawing.Size(28, 20);
            this.txtChoosen.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 484);
            this.Controls.Add(this.txtChoosen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnUnique);
            this.Controls.Add(this.btnOriginal);
            this.Controls.Add(this.pic1);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtClusters);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCompute);
            this.Controls.Add(this.btnUpload);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnCompute;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClusters;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.Button btnOriginal;
        private System.Windows.Forms.Button btnUnique;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtChoosen;
    }
}

