namespace ProducerConsumer
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
            this.btnStartConsumer = new System.Windows.Forms.Button();
            this.btnConsumerMR = new System.Windows.Forms.Button();
            this.btnStartProducer = new System.Windows.Forms.Button();
            this.btnProducerMR = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStartConsumer
            // 
            this.btnStartConsumer.Location = new System.Drawing.Point(41, 76);
            this.btnStartConsumer.Name = "btnStartConsumer";
            this.btnStartConsumer.Size = new System.Drawing.Size(90, 23);
            this.btnStartConsumer.TabIndex = 0;
            this.btnStartConsumer.Text = "Start Consumer";
            this.btnStartConsumer.UseVisualStyleBackColor = true;
            this.btnStartConsumer.Click += new System.EventHandler(this.btnStartConsumer_Click);
            // 
            // btnConsumerMR
            // 
            this.btnConsumerMR.Location = new System.Drawing.Point(41, 126);
            this.btnConsumerMR.Name = "btnConsumerMR";
            this.btnConsumerMR.Size = new System.Drawing.Size(90, 23);
            this.btnConsumerMR.TabIndex = 1;
            this.btnConsumerMR.Text = "Consumer MR";
            this.btnConsumerMR.UseVisualStyleBackColor = true;
            this.btnConsumerMR.Click += new System.EventHandler(this.btnConsumerMR_Click);
            // 
            // btnStartProducer
            // 
            this.btnStartProducer.Location = new System.Drawing.Point(154, 76);
            this.btnStartProducer.Name = "btnStartProducer";
            this.btnStartProducer.Size = new System.Drawing.Size(84, 23);
            this.btnStartProducer.TabIndex = 2;
            this.btnStartProducer.Text = "Start Producer";
            this.btnStartProducer.UseVisualStyleBackColor = true;
            this.btnStartProducer.Click += new System.EventHandler(this.btnStartProducer_Click);
            // 
            // btnProducerMR
            // 
            this.btnProducerMR.Location = new System.Drawing.Point(154, 126);
            this.btnProducerMR.Name = "btnProducerMR";
            this.btnProducerMR.Size = new System.Drawing.Size(84, 23);
            this.btnProducerMR.TabIndex = 3;
            this.btnProducerMR.Text = "Producer MR";
            this.btnProducerMR.UseVisualStyleBackColor = true;
            this.btnProducerMR.Click += new System.EventHandler(this.btnProducerMR_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 250);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(290, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(53, 192);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 272);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnProducerMR);
            this.Controls.Add(this.btnStartProducer);
            this.Controls.Add(this.btnConsumerMR);
            this.Controls.Add(this.btnStartConsumer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartConsumer;
        private System.Windows.Forms.Button btnConsumerMR;
        private System.Windows.Forms.Button btnStartProducer;
        private System.Windows.Forms.Button btnProducerMR;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label lblStatus;
    }
}

