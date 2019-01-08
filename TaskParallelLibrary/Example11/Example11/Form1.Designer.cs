namespace Example11
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
            this.btnStarTaskWithCancelToken = new System.Windows.Forms.Button();
            this.btnStopWCancelToken = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStarTaskWithCancelToken
            // 
            this.btnStarTaskWithCancelToken.Location = new System.Drawing.Point(157, 94);
            this.btnStarTaskWithCancelToken.Name = "btnStarTaskWithCancelToken";
            this.btnStarTaskWithCancelToken.Size = new System.Drawing.Size(75, 23);
            this.btnStarTaskWithCancelToken.TabIndex = 0;
            this.btnStarTaskWithCancelToken.Text = "Start";
            this.btnStarTaskWithCancelToken.UseVisualStyleBackColor = true;
            this.btnStarTaskWithCancelToken.Click += new System.EventHandler(this.btnStarTaskWithCancelToken_Click);
            // 
            // btnStopWCancelToken
            // 
            this.btnStopWCancelToken.Location = new System.Drawing.Point(157, 170);
            this.btnStopWCancelToken.Name = "btnStopWCancelToken";
            this.btnStopWCancelToken.Size = new System.Drawing.Size(75, 23);
            this.btnStopWCancelToken.TabIndex = 1;
            this.btnStopWCancelToken.Text = "Stop";
            this.btnStopWCancelToken.UseVisualStyleBackColor = true;
            this.btnStopWCancelToken.Click += new System.EventHandler(this.btnStopWCancelToken_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 310);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(409, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 332);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnStopWCancelToken);
            this.Controls.Add(this.btnStarTaskWithCancelToken);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStarTaskWithCancelToken;
        private System.Windows.Forms.Button btnStopWCancelToken;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}

