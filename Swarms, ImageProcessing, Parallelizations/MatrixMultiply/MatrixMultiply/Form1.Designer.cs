namespace MatrixMultiply
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
            this.btnInitializeMatrix = new System.Windows.Forms.Button();
            this.btnMatrixMultiply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInitializeMatrix
            // 
            this.btnInitializeMatrix.Location = new System.Drawing.Point(115, 87);
            this.btnInitializeMatrix.Name = "btnInitializeMatrix";
            this.btnInitializeMatrix.Size = new System.Drawing.Size(99, 23);
            this.btnInitializeMatrix.TabIndex = 0;
            this.btnInitializeMatrix.Text = "Matrix Initialize";
            this.btnInitializeMatrix.UseVisualStyleBackColor = true;
            this.btnInitializeMatrix.Click += new System.EventHandler(this.btnInitializeMatrix_Click);
            // 
            // btnMatrixMultiply
            // 
            this.btnMatrixMultiply.Location = new System.Drawing.Point(115, 175);
            this.btnMatrixMultiply.Name = "btnMatrixMultiply";
            this.btnMatrixMultiply.Size = new System.Drawing.Size(99, 23);
            this.btnMatrixMultiply.TabIndex = 1;
            this.btnMatrixMultiply.Text = "Matrix Multiply";
            this.btnMatrixMultiply.UseVisualStyleBackColor = true;
            this.btnMatrixMultiply.Click += new System.EventHandler(this.btnMatrixMultiply_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 289);
            this.Controls.Add(this.btnMatrixMultiply);
            this.Controls.Add(this.btnInitializeMatrix);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInitializeMatrix;
        private System.Windows.Forms.Button btnMatrixMultiply;
    }
}

