namespace LUDecompoistion
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
            this.btnComputeLU = new System.Windows.Forms.Button();
            this.btnLInverse = new System.Windows.Forms.Button();
            this.btnUInverse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnComputeLU
            // 
            this.btnComputeLU.Location = new System.Drawing.Point(130, 46);
            this.btnComputeLU.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnComputeLU.Name = "btnComputeLU";
            this.btnComputeLU.Size = new System.Drawing.Size(244, 45);
            this.btnComputeLU.TabIndex = 0;
            this.btnComputeLU.Text = "Compute LU";
            this.btnComputeLU.UseVisualStyleBackColor = true;
            this.btnComputeLU.Click += new System.EventHandler(this.btnComputeLU_Click);
            // 
            // btnLInverse
            // 
            this.btnLInverse.Location = new System.Drawing.Point(130, 124);
            this.btnLInverse.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnLInverse.Name = "btnLInverse";
            this.btnLInverse.Size = new System.Drawing.Size(244, 45);
            this.btnLInverse.TabIndex = 1;
            this.btnLInverse.Text = "LInverse";
            this.btnLInverse.UseVisualStyleBackColor = true;
            this.btnLInverse.Click += new System.EventHandler(this.btnLInverse_Click);
            // 
            // btnUInverse
            // 
            this.btnUInverse.Location = new System.Drawing.Point(130, 211);
            this.btnUInverse.Margin = new System.Windows.Forms.Padding(6);
            this.btnUInverse.Name = "btnUInverse";
            this.btnUInverse.Size = new System.Drawing.Size(244, 45);
            this.btnUInverse.TabIndex = 2;
            this.btnUInverse.Text = "UInverse";
            this.btnUInverse.UseVisualStyleBackColor = true;
            this.btnUInverse.Click += new System.EventHandler(this.btnUInverse_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 653);
            this.Controls.Add(this.btnUInverse);
            this.Controls.Add(this.btnLInverse);
            this.Controls.Add(this.btnComputeLU);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnComputeLU;
        private System.Windows.Forms.Button btnLInverse;
        private System.Windows.Forms.Button btnUInverse;
    }
}

