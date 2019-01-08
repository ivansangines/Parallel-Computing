using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example11
{
    public partial class Form1 : Form
    {
        DelShow delShowTime = null;
        DelShow delShowTicks = null;
        delegate void DelShow(string msg);
        Task tskShowTime = null;
        Task tskTicks = null;
        CancellationTokenSource cancelTokenSource = null;
        CancellationTokenSource cancelTokenSourceShowTime = null;
        CancellationTokenSource cancelTokenSourceShowStockPrice = null;



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
            while (true)
            {
                try
                {
                    if (statusStrip1.InvokeRequired)
                    {
                        statusStrip1.Invoke(delShowTime, new string[] { DateTime.Now.ToLongTimeString() });
                    }
                    canToken.WaitHandle.WaitOne(5000);
                    canToken.ThrowIfCancellationRequested();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        void ShowTicks(CancellationToken canToken)
        {
            while (true)
            {
                try
                {
                    if (statusStrip1.InvokeRequired)
                    {
                        statusStrip1.Invoke(delShowTicks, new string[] { DateTime.Now.Ticks.ToString() });
                    }
                    canToken.WaitHandle.WaitOne(5000);
                    canToken.ThrowIfCancellationRequested();

                    //THIS WILL PRODUCE A LOCKDEAD
                    //canToken.ThrowIfCancellationRequested();
                    //canToken.WaitHandle.WaitOne(15000);

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        void UpdateTime(string msg)
        {
            lblStatus.Text = msg;
        }

        void UpdateTicks(string msg)
        {
            lblStat2.Text = msg;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            delShowTime = new DelShow(this.UpdateTime);
            delShowTicks = new DelShow(this.UpdateTicks);
        }


        private void btnStart2Tasks_Click(object sender, EventArgs e)
        {
            // ShowTime task
            if (tskShowTime == null)
            {
                cancelTokenSource = new CancellationTokenSource();
                CancellationToken cancelToken1 = cancelTokenSource.Token;
                tskShowTime = new Task(() => ShowTime(cancelToken1), cancelToken1);
            }
            if (tskShowTime.IsCompleted)
            {
                cancelTokenSource = new CancellationTokenSource();
                CancellationToken cancelToken1 = cancelTokenSource.Token;
                tskShowTime = new Task(() => ShowTime(cancelToken1), cancelToken1);
            }
            if (tskShowTime.Status != TaskStatus.Running)
                tskShowTime.Start();

            // Ticks task
            if (tskTicks == null)
            {
                CancellationToken cancelToken2 = cancelTokenSource.Token;
                tskTicks = new Task(() => ShowTicks(cancelToken2), cancelToken2);
            }
            if (tskTicks.IsCompleted)
            {
                CancellationToken cancelToken2 = cancelTokenSource.Token;
                tskTicks = new Task(() => ShowTicks(cancelToken2), cancelToken2);
            }
            if (tskTicks.Status != TaskStatus.Running)
                tskTicks.Start();
        }

/* I THINK THERE IS SOME KIND OF PROBLEM WITH THE WEBSITE, USING SHOWTICKS() INSTEAD OF SHOWSTOCKPRICE()
        void ShowStockPrice(CancellationToken canToken)
        {
            while (true)
            {
                try
                {
                    WebClient wbc = new WebClient();
                    byte[] bdata = wbc.DownloadData("http://www.nasdaq.com/aspx/infoquotes.aspx?symbol=IBM&selected=IBM");
                    string pageText = new UTF8Encoding().GetString(bdata);
                    int pos1 = pageText.IndexOf("LastSale1'>");
                    int pos2 = pageText.IndexOf("</", pos1 + 1);
                    string price = pageText.Substring(pos1 + 18, pos2 - pos1 - 18);
                    if (statusStrip1.InvokeRequired)
                    {
                        statusStrip1.Invoke(delShowStockPrice, new string[] { price });
                    }

                    canToken.WaitHandle.WaitOne(1000);
                    // this has to be before
                    // ThrowIfCancellationRequested, otherwise causes deadlock
                    // if cancellation is not done in a separate task
                    canToken.ThrowIfCancellationRequested();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
*/


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

        private void btnCancel2Tasks_Click(object sender, EventArgs e)
        {
            Task tCancel = new Task(CancelAllTasks);
            tCancel.Start();
/*
            try
            {
                cancelTokenSource.Cancel();  // cancel tasks

                Task.WaitAll(tskShowTime, tskTicks);
                // takes variable number of task objects or a task array

            }
            catch (AggregateException ex)
            {
                lblStatus.Text = tskShowTime.Status.ToString();
                lblStat2.Text = tskTicks.Status.ToString();
                foreach (var ee in ex.InnerExceptions)
                {
                    MessageBox.Show(ee.GetType() + ":" + ee.Message);
                }
            }
*/
        }
        void CancelAllTasks()
        {
            try
            {
                cancelTokenSource.Cancel();  // cancel tasks
                Task.WaitAll(tskShowTime, tskTicks);
            }
            catch (AggregateException ex) // parallel framework excep.
            {
                statusStrip1.Invoke(delShowTime, new string[] { tskShowTime.Status.ToString() });
                statusStrip1.Invoke(delShowTicks, new string[] { tskTicks.Status.ToString() });
                foreach (var ee in ex.InnerExceptions)
                {
                    MessageBox.Show(ee.GetType() + ":" + ee.Message);
                }
            }
        }

        private void btnstart2TasksWSepTokenSource_Click(object sender, EventArgs e)
        {
            // ShowTime task
            if (tskShowTime == null)
            {
                cancelTokenSourceShowTime = new CancellationTokenSource();
                CancellationToken cancelToken1 = cancelTokenSourceShowTime.Token;
                tskShowTime = new Task(() => ShowTime(cancelToken1), cancelToken1);
            }
            if (tskShowTime.IsCompleted)
            {
                cancelTokenSourceShowTime = new CancellationTokenSource();
                CancellationToken cancelToken1 = cancelTokenSourceShowTime.Token;
                tskShowTime = new Task(() => ShowTime(cancelToken1), cancelToken1);
            }
            if (tskShowTime.Status != TaskStatus.Running)
                tskShowTime.Start();

            // Ticks task
            if (tskTicks == null)
            {
                cancelTokenSourceShowStockPrice = new CancellationTokenSource();
                CancellationToken cancelToken2 = cancelTokenSourceShowStockPrice.Token;
                //cancelToken2.Register(ShowTicksCancelled);
                Action<object> cancelCallback = new Action<object>(ShowTicksCancelled2);
                cancelToken2.Register(cancelCallback, DateTime.Now);

                tskTicks = new Task(() => ShowTicks(cancelToken2), cancelToken2);
            }
            if (tskTicks.IsCompleted)
            {
                cancelTokenSourceShowStockPrice = new CancellationTokenSource();
                CancellationToken cancelToken2 = cancelTokenSourceShowStockPrice.Token;
                tskTicks = new Task(() => ShowTicks(cancelToken2), cancelToken2);
            }
            if (tskTicks.Status != TaskStatus.Running)
                tskTicks.Start();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Task tcancel = new Task(() =>
            {
                try
                {
                    cancelTokenSourceShowStockPrice.Cancel();
                    tskTicks.Wait();
                }
                catch (AggregateException ae)
                {
                    statusStrip1.Invoke(delShowTicks, new string[] { tskTicks.Status.ToString() });
                }
            });
            tcancel.Start();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Task tcancel = new Task(() =>
            {
                try
                {
                    cancelTokenSourceShowTime.Cancel();
                    tskShowTime.Wait();
                }
                catch (AggregateException ae)
                {
                    statusStrip1.Invoke(delShowTime, new string[] { tskShowTime.Status.ToString() });
                }
            });
            tcancel.Start();

        }

        void ShowTicksCancelled()
        {
            MessageBox.Show("Show Price Task has been cancelled..");
        }

        void ShowTicksCancelled2(object state)
        {
            MessageBox.Show("Show Ticks Task has been cancelled..\n" +
                "Task was started at: " + state.ToString());
        }


    }
}
