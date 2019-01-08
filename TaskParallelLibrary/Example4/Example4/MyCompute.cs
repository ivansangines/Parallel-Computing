using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Example4
{
    class MyCompute
    {
        public double Compute(object p)
        {
            double result = (float)p * 21.77 - 23.33;
            Thread.Sleep(5000);
            return result;
        }

        public double Compute2(float a, float b)
        {
            double result = a * b - 23.33;
            Thread.Sleep(1000);
            return result;
        }
    }

}
