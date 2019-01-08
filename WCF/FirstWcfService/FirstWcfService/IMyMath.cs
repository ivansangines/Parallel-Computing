using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace FirstWcfService
{
    [ServiceContract]
    public interface IMyMath
    {
        [OperationContract]
        double ComputeAvg(int a, int b, int c);
        [OperationContract]
        int FindMin(int a, int b, int c);
    }
}
