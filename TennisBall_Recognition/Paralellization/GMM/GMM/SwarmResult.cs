using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMM
{
    class SwarmResult : IComparable<SwarmResult>
    {
        public int SwarmId { get; set; }
        public double FunctionValue { get; set; }
        public List<MyPoint> BestList { get; set; }

        /*
        public SwarmResult(SwarmSystem obj)
        {
            this.SwarmId = obj.SwarmNum;
            //this.FunctionValue = obj.f;
            this.BestList = obj.BestPList;
        }
        */

        public SwarmResult(int swarmId, double Function)
        {
            this.SwarmId = swarmId;
            this.FunctionValue = Function;
            
        }

        public override string ToString()
        {
            return "SwarmId:" + SwarmId.ToString() +
            " Function Value=" + FunctionValue.ToString();
        }
        public int CompareTo(SwarmResult other)
        {
            return this.FunctionValue.CompareTo(other.FunctionValue);
        }
    }
}
