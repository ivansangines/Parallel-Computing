using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace SemaphoreTest
{
    class LimoCar
    {
        public LimoCar(int num, int time)
        {
            limoNumber = num;
            travelTime = time; // specified in seconds
            semLim = new Semaphore(4, 4);
            // second parameter indicates max users
            // that can access the resource
            // first parameter, if it is zero, denies
            // access to the resource
            // each access reduces the value in the
            // first parameter
        }
        object olock = new object();
        Semaphore semLim = null;
        int limoNumber;
        public int LimoNumber
        {
            get { return limoNumber; }
            set { limoNumber = value; }
        }
        int travelTime;
        public int TravelTime
        {
            get { return travelTime; }
            set { travelTime = value; }
        }
        int customersInLimo = 0;
        public int CustomersInLimo
        {
            get { lock (olock) { return customersInLimo; } }
        }
        public void UseLimo()
        {
            semLim.WaitOne(); // check if gate is open
            lock (olock) { customersInLimo++; }
            MessageBox.Show("OK to use limo..\n" + "Currently " + customersInLimo.ToString() +  " Customers in limo");
            Thread.Sleep(1000 * travelTime);
            semLim.Release(); // increment gate count
            lock (olock) { customersInLimo--; }
        }
    }
}
