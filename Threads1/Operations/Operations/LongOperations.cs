using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Operations
{
    class LongOperations
    {
        object olock = new object();
        bool terminate = false;
        public bool Terminate
        {
            set { lock (olock) { terminate = value; } }
        }
        double stockPrice;
        public double StockPrice
        {
            get { lock (olock) { return stockPrice; } }
        }
        int temperature;
        public int Temperature
        {
            get { lock (olock) { return temperature; } }
        }
        int data;
        public int Data
        {
            get { lock (olock) { return data; } }
            set { lock (olock) { data = value; } }
        }
        double result;
        public double Result
        {
            get { lock (olock) { return result; } }
        }
        public void Compute()
        {
            double res = 2.7575 + data / 3.8686 - 5.66;
            Thread.Sleep(5000); // assume it takes 5 secs 
            lock (olock) // to produce result
            {
                result = res;
            }
        }
        public void GetWeather()
        {
            Random rn = new Random((int)DateTime.Now.Ticks);
           
            while (true)
            {
                // suppose we are obtaining temperatur info
                // from a web service and it takes 2 seconds
                // to get data from it
                Thread.Sleep(2000);
                lock (olock) { temperature = 80 + rn.Next(2, 8); }
            }
        }
        public void GetStockPrice()
        {
            Random rn = new Random((int)DateTime.Now.Ticks);
            bool term = false;
            lock (olock) { term = terminate; }
            
            while (term == false)
            {
                Thread.Sleep(3000); // pretend it takes
                                    // 3 seconds to get the stock price
                lock (olock)
                {
                    stockPrice = 100 + rn.NextDouble() * 10;
                }
                Thread.Sleep(10); // pretend it takes
                                  // 10 milliseconds to write to DB
                lock (olock) { term = terminate; }
            }
        }

    }
}
