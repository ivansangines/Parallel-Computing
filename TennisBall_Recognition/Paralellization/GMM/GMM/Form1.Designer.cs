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
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.btnInitialize = new System.Windows.Forms.Button();
            this.btnSwarms = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCluster = new System.Windows.Forms.TextBox();
            this.btnClusters = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pic1
            // 
            this.pic1.Location = new System.Drawing.Point(170, 17);
            this.pic1.Margin = new System.Windows.Forms.Padding(1);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(453, 362);
            this.pic1.TabIndex = 5;
            this.pic1.TabStop = false;
            // 
            // btnInitialize
            // 
            this.btnInitialize.Location = new System.Drawing.Point(29, 12);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(110, 23);
            this.btnInitialize.TabIndex = 6;
            this.btnInitialize.Text = "Initialize Data";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // btnSwarms
            // 
            this.btnSwarms.Location = new System.Drawing.Point(29, 81);
            this.btnSwarms.Name = "btnSwarms";
            this.btnSwarms.Size = new System.Drawing.Size(110, 23);
            this.btnSwarms.TabIndex = 7;
            this.btnSwarms.Text = "Compute Swarms";
            this.btnSwarms.UseVisualStyleBackColor = true;
            this.btnSwarms.Click += new System.EventHandler(this.btnSwarms_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(170, 383);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(453, 150);
            this.dataGridView1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 383);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Number of Clusters:";
            // 
            // txtCluster
            // 
            this.txtCluster.Location = new System.Drawing.Point(124, 383);
            this.txtCluster.Name = "txtCluster";
            this.txtCluster.Size = new System.Drawing.Size(26, 20);
            this.txtCluster.TabIndex = 10;
            // 
            // btnClusters
            // 
            this.btnClusters.Location = new System.Drawing.Point(63, 423);
            this.btnClusters.Name = "btnClusters";
            this.btnClusters.Size = new System.Drawing.Size(87, 23);
            this.btnClusters.TabIndex = 11;
            this.btnClusters.Text = "Show Clusters";
            this.btnClusters.UseVisualStyleBackColor = true;
            this.btnClusters.Click += new System.EventHandler(this.btnClusters_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 565);
            this.Controls.Add(this.btnClusters);
            this.Controls.Add(this.txtCluster);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSwarms);
            this.Controls.Add(this.btnInitialize);
            this.Controls.Add(this.pic1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.Button btnInitialize;
        private System.Windows.Forms.Button btnSwarms;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCluster;
        private System.Windows.Forms.Button btnClusters;
    }
}

