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
            this.btnStart2Tasks = new System.Windows.Forms.Button();
            this.btnCancel2Tasks = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStat2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnstart2TasksWSepTokenSource = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStarTaskWithCancelToken
            // 
            this.btnStarTaskWithCancelToken.Location = new System.Drawing.Point(37, 47);
            this.btnStarTaskWithCancelToken.Name = "btnStarTaskWithCancelToken";
            this.btnStarTaskWithCancelToken.Size = new System.Drawing.Size(75, 23);
            this.btnStarTaskWithCancelToken.TabIndex = 0;
            this.btnStarTaskWithCancelToken.Text = "Start";
            this.btnStarTaskWithCancelToken.UseVisualStyleBackColor = true;
            this.btnStarTaskWithCancelToken.Click += new System.EventHandler(this.btnStarTaskWithCancelToken_Click);
            // 
            // btnStopWCancelToken
            // 
            this.btnStopWCancelToken.Location = new System.Drawing.Point(37, 115);
            this.btnStopWCancelToken.Name = "btnStopWCancelToken";
            this.btnStopWCancelToken.Size = new System.Drawing.Size(75, 23);
            this.btnStopWCancelToken.TabIndex = 1;
            this.btnStopWCancelToken.Text = "Stop";
            this.btnStopWCancelToken.UseVisualStyleBackColor = true;
            this.btnStopWCancelToken.Click += new System.EventHandler(this.btnStopWCancelToken_Click);
            // 
            // btnStart2Tasks
            // 
            this.btnStart2Tasks.Location = new System.Drawing.Point(272, 47);
            this.btnStart2Tasks.Name = "btnStart2Tasks";
            this.btnStart2Tasks.Size = new System.Drawing.Size(75, 23);
            this.btnStart2Tasks.TabIndex = 3;
            this.btnStart2Tasks.Text = "Start 2";
            this.btnStart2Tasks.UseVisualStyleBackColor = true;
            this.btnStart2Tasks.Click += new System.EventHandler(this.btnStart2Tasks_Click);
            // 
            // btnCancel2Tasks
            // 
            this.btnCancel2Tasks.Location = new System.Drawing.Point(272, 115);
            this.btnCancel2Tasks.Name = "btnCancel2Tasks";
            this.btnCancel2Tasks.Size = new System.Drawing.Size(75, 23);
            this.btnCancel2Tasks.TabIndex = 4;
            this.btnCancel2Tasks.Text = "Stop2";
            this.btnCancel2Tasks.UseVisualStyleBackColor = true;
            this.btnCancel2Tasks.Click += new System.EventHandler(this.btnCancel2Tasks_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblStat2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 310);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(409, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = false;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(118, 17);
            // 
            // lblStat2
            // 
            this.lblStat2.AutoSize = false;
            this.lblStat2.Margin = new System.Windows.Forms.Padding(100, 3, 0, 2);
            this.lblStat2.Name = "lblStat2";
            this.lblStat2.Size = new System.Drawing.Size(118, 17);
            // 
            // btnstart2TasksWSepTokenSource
            // 
            this.btnstart2TasksWSepTokenSource.Location = new System.Drawing.Point(49, 230);
            this.btnstart2TasksWSepTokenSource.Name = "btnstart2TasksWSepTokenSource";
            this.btnstart2TasksWSepTokenSource.Size = new System.Drawing.Size(95, 23);
            this.btnstart2TasksWSepTokenSource.TabIndex = 8;
            this.btnstart2TasksWSepTokenSource.Text = "Start_Separated";
            this.btnstart2TasksWSepTokenSource.UseVisualStyleBackColor = true;
            this.btnstart2TasksWSepTokenSource.Click += new System.EventHandler(this.btnstart2TasksWSepTokenSource_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(188, 192);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Stop_Task1";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(188, 270);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Stop_Task2";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 332);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnstart2TasksWSepTokenSource);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnCancel2Tasks);
            this.Controls.Add(this.btnStart2Tasks);
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
        private System.Windows.Forms.Button btnStart2Tasks;
        private System.Windows.Forms.Button btnCancel2Tasks;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblStat2;
        private System.Windows.Forms.Button btnstart2TasksWSepTokenSource;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

