using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example11
{
    public partial class Form1 : Form
    {
        DelShowTime delShowTime = null;
        delegate void DelShowTime(string msg);
        Task tskShowTime = null;
        CancellationTokenSource cancelTokenSource = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStarTaskWithCancelToken_Click(object sender, EventArgs e)
        {
            cancelTokenSource = new CancellationTokenSource();
            CancellationToken cancelToken = cancelTokenSource.Token;
            if (tskShowTime == null)
                tskShowTime = new Task(() => ShowTime(cancelToken), cancelToken);
            if (tskShowTime.IsCompleted)
                tskShowTime = new Task(() => ShowTime(cancelToken), cancelToken);
            tskShowTime.Start();

        }

        void ShowTime(CancellationToken canToken)
        {
            //while (bTerminate == false)
            while (true)
            {
                if (statusStrip1.InvokeRequired)
                {
                    // if (bTerminate == false)
                    statusStrip1.Invoke(delShowTime, new string[] { DateTime.Now.ToLongTimeString() });
                }
                /*Thread.Sleep(1000);
                if (canToken.IsCancellationRequested == true)
                    throw new OperationCanceledException(canToken); */
                canToken.WaitHandle.WaitOne(15000);
                canToken.ThrowIfCancellationRequested();
            }
        }

        void UpdateTime(string msg)
        {
            lblStatus.Text = msg;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            delShowTime = new DelShowTime(this.UpdateTime);
        }

        private void btnStopWCancelToken_Click(object sender, EventArgs e)
        {

            try
            {
                cancelTokenSource.Cancel();  // cancel tasks
                if (tskShowTime != null)
                {
                    if (tskShowTime.Status == TaskStatus.Running)
                        tskShowTime.Wait();
                }
            }
            catch (AggregateException ex) // exception in parallel framework
            {
                lblStatus.Text = tskShowTime.Status.ToString();
                foreach (var ee in ex.InnerExceptions)
                { // important if many tasks are being cancelled
                    MessageBox.Show(ee.Message);
                }
            }

        }
    }
}
