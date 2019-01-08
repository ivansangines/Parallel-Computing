using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himmelblau_s
{
    class SwarmResult : IComparable<SwarmResult>, IEqualityComparer<SwarmResult>
    {
        public int SwarmId { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double FunctionValue { get; set; }
        public override string ToString()
        {
            return "SwarmId:" + SwarmId.ToString() +
            " X=" + X.ToString() +
            " Y=" + Y.ToString() +
            "Function Value=" + FunctionValue.ToString();
        }

        public int CompareTo(SwarmResult other)
        {
            return this.FunctionValue.CompareTo(other.FunctionValue);
        }
        
        public bool Equals(SwarmResult first, SwarmResult second)
        {
            //I rounded because I had cases where the last decimal place was different
            return Math.Round(first.X,2)==Math.Round(second.X,2); 
        }

        public int GetHashCode(SwarmResult obj)
        {
            return obj.X.GetHashCode();
        }
        
    }
}
