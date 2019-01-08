using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading2
{
    class Employee
    {
        object olock1 = new object();
        object olock2 = new object();
        int hoursWorked;
        public int HoursWorked
        {
            get { lock (olock1) { return hoursWorked; } }
            set { lock (olock1) { hoursWorked = value; } }
        }
        double payRate;
        public double PayRate
        {
            get { lock (olock2) { return payRate; } }
            set { lock (olock2) { payRate = value; } }
        }
        public double ComputePay()
        {
            //lock (olock1)
            //{
            // return hoursWorked * payRate;
            //}
            double hours = 0;
            lock (olock1)
            {
                hours = hoursWorked;
            }
            double rate = 0;
            lock (olock2)
            {
                rate = payRate;
            }
            return hours * rate;
        }

    }
}
