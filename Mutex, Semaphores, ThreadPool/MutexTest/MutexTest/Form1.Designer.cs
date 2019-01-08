namespace MutexTest
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
            this.btnMutexTest = new System.Windows.Forms.Button();
            this.sb1 = new System.Windows.Forms.StatusBar();
            this.SuspendLayout();
            // 
            // btnMutexTest
            // 
            this.btnMutexTest.Location = new System.Drawing.Point(99, 106);
            this.btnMutexTest.Name = "btnMutexTest";
            this.btnMutexTest.Size = new System.Drawing.Size(75, 23);
            this.btnMutexTest.TabIndex = 0;
            this.btnMutexTest.Text = "Launch";
            this.btnMutexTest.UseVisualStyleBackColor = true;
            this.btnMutexTest.Click += new System.EventHandler(this.btnMutexTest_Click);
            // 
            // sb1
            // 
            this.sb1.Location = new System.Drawing.Point(0, 226);
            this.sb1.Name = "sb1";
            this.sb1.Size = new System.Drawing.Size(267, 22);
            this.sb1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 248);
            this.Controls.Add(this.sb1);
            this.Controls.Add(this.btnMutexTest);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMutexTest;
        private System.Windows.Forms.StatusBar sb1;
    }
}

