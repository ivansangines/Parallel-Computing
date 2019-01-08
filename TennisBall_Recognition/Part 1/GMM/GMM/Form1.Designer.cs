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
            this.txtNum = new System.Windows.Forms.TextBox();
            this.btnClass = new System.Windows.Forms.Button();
            this.btnGMM = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(224, 129);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(100, 20);
            this.txtNum.TabIndex = 0;
            // 
            // btnClass
            // 
            this.btnClass.Location = new System.Drawing.Point(76, 126);
            this.btnClass.Name = "btnClass";
            this.btnClass.Size = new System.Drawing.Size(75, 23);
            this.btnClass.TabIndex = 1;
            this.btnClass.Text = "Test Class";
            this.btnClass.UseVisualStyleBackColor = true;
            this.btnClass.Click += new System.EventHandler(this.btnClass_Click);
            // 
            // btnGMM
            // 
            this.btnGMM.Location = new System.Drawing.Point(76, 65);
            this.btnGMM.Name = "btnGMM";
            this.btnGMM.Size = new System.Drawing.Size(75, 23);
            this.btnGMM.TabIndex = 2;
            this.btnGMM.Text = "Test GMM";
            this.btnGMM.UseVisualStyleBackColor = true;
            this.btnGMM.Click += new System.EventHandler(this.btnGMM_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter Number:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 290);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGMM);
            this.Controls.Add(this.btnClass);
            this.Controls.Add(this.txtNum);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Button btnClass;
        private System.Windows.Forms.Button btnGMM;
        private System.Windows.Forms.Label label1;
    }
}

