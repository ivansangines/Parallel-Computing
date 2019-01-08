namespace FirstWCFClient
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
            this.btnTestWCFMyMath = new System.Windows.Forms.Button();
            this.btnWCFProxy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTestWCFMyMath
            // 
            this.btnTestWCFMyMath.Location = new System.Drawing.Point(112, 40);
            this.btnTestWCFMyMath.Name = "btnTestWCFMyMath";
            this.btnTestWCFMyMath.Size = new System.Drawing.Size(110, 23);
            this.btnTestWCFMyMath.TabIndex = 0;
            this.btnTestWCFMyMath.Text = "Test WCF MyMath";
            this.btnTestWCFMyMath.UseVisualStyleBackColor = true;
            this.btnTestWCFMyMath.Click += new System.EventHandler(this.btnTestWCFMyMath_Click);
            // 
            // btnWCFProxy
            // 
            this.btnWCFProxy.Location = new System.Drawing.Point(112, 113);
            this.btnWCFProxy.Name = "btnWCFProxy";
            this.btnWCFProxy.Size = new System.Drawing.Size(110, 23);
            this.btnWCFProxy.TabIndex = 1;
            this.btnWCFProxy.Text = "Test WCF via Proxy";
            this.btnWCFProxy.UseVisualStyleBackColor = true;
            this.btnWCFProxy.Click += new System.EventHandler(this.btnWCFProxy_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 221);
            this.Controls.Add(this.btnWCFProxy);
            this.Controls.Add(this.btnTestWCFMyMath);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTestWCFMyMath;
        private System.Windows.Forms.Button btnWCFProxy;
    }
}

