namespace ImageProcessing
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
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.btnConvertToGray = new System.Windows.Forms.Button();
            this.btnConvertToGrayUnsafe = new System.Windows.Forms.Button();
            this.btnConvertToGrayParalle = new System.Windows.Forms.Button();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(16, 95);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(93, 23);
            this.btnLoadImage.TabIndex = 0;
            this.btnLoadImage.Text = "Load Image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // btnConvertToGray
            // 
            this.btnConvertToGray.Location = new System.Drawing.Point(16, 155);
            this.btnConvertToGray.Name = "btnConvertToGray";
            this.btnConvertToGray.Size = new System.Drawing.Size(93, 23);
            this.btnConvertToGray.TabIndex = 1;
            this.btnConvertToGray.Text = "Convert to Gray";
            this.btnConvertToGray.UseVisualStyleBackColor = true;
            this.btnConvertToGray.Click += new System.EventHandler(this.btnConvertToGray_Click);
            // 
            // btnConvertToGrayUnsafe
            // 
            this.btnConvertToGrayUnsafe.Location = new System.Drawing.Point(16, 208);
            this.btnConvertToGrayUnsafe.Name = "btnConvertToGrayUnsafe";
            this.btnConvertToGrayUnsafe.Size = new System.Drawing.Size(93, 35);
            this.btnConvertToGrayUnsafe.TabIndex = 2;
            this.btnConvertToGrayUnsafe.Text = "Convert to Gray Unsafe";
            this.btnConvertToGrayUnsafe.UseVisualStyleBackColor = true;
            this.btnConvertToGrayUnsafe.Click += new System.EventHandler(this.btnConvertToGrayUnsafe_Click);
            // 
            // btnConvertToGrayParalle
            // 
            this.btnConvertToGrayParalle.Location = new System.Drawing.Point(16, 269);
            this.btnConvertToGrayParalle.Name = "btnConvertToGrayParalle";
            this.btnConvertToGrayParalle.Size = new System.Drawing.Size(93, 39);
            this.btnConvertToGrayParalle.TabIndex = 3;
            this.btnConvertToGrayParalle.Text = "Convert to Gray Parallel Unsafe";
            this.btnConvertToGrayParalle.UseVisualStyleBackColor = true;
            this.btnConvertToGrayParalle.Click += new System.EventHandler(this.btnConvertToGrayParalle_Click);
            // 
            // pic1
            // 
            this.pic1.Location = new System.Drawing.Point(147, 69);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(734, 458);
            this.pic1.TabIndex = 4;
            this.pic1.TabStop = false;
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(193, 53);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(35, 13);
            this.lblWidth.TabIndex = 5;
            this.lblWidth.Text = "label1";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(283, 53);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(35, 13);
            this.lblHeight.TabIndex = 6;
            this.lblHeight.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 539);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.pic1);
            this.Controls.Add(this.btnConvertToGrayParalle);
            this.Controls.Add(this.btnConvertToGrayUnsafe);
            this.Controls.Add(this.btnConvertToGray);
            this.Controls.Add(this.btnLoadImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnConvertToGray;
        private System.Windows.Forms.Button btnConvertToGrayUnsafe;
        private System.Windows.Forms.Button btnConvertToGrayParalle;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblHeight;
    }
}

