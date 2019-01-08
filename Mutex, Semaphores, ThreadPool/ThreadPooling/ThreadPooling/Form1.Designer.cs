namespace ThreadPooling
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
            this.btnThreadPool = new System.Windows.Forms.Button();
            this.btnThreadPoolArray = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnThreadPool
            // 
            this.btnThreadPool.Location = new System.Drawing.Point(104, 77);
            this.btnThreadPool.Name = "btnThreadPool";
            this.btnThreadPool.Size = new System.Drawing.Size(75, 23);
            this.btnThreadPool.TabIndex = 0;
            this.btnThreadPool.Text = "Launch";
            this.btnThreadPool.UseVisualStyleBackColor = true;
            this.btnThreadPool.Click += new System.EventHandler(this.btnThreadPool_Click);
            // 
            // btnThreadPoolArray
            // 
            this.btnThreadPoolArray.Location = new System.Drawing.Point(104, 140);
            this.btnThreadPoolArray.Name = "btnThreadPoolArray";
            this.btnThreadPoolArray.Size = new System.Drawing.Size(75, 23);
            this.btnThreadPoolArray.TabIndex = 1;
            this.btnThreadPoolArray.Text = "Using Array";
            this.btnThreadPoolArray.UseVisualStyleBackColor = true;
            this.btnThreadPoolArray.Click += new System.EventHandler(this.btnThreadPoolArray_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 269);
            this.Controls.Add(this.btnThreadPoolArray);
            this.Controls.Add(this.btnThreadPool);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnThreadPool;
        private System.Windows.Forms.Button btnThreadPoolArray;
    }
}

