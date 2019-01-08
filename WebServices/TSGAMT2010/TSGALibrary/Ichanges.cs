using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TSGALibrary
{
    public interface IChangeCallBack
    {
        [OperationContract(IsOneWay = true)]
        void OnBestPathChange(TSGAInfo tinfo);
    }

    [ServiceContract(CallbackContract = typeof(IChangeCallBack))]
    public interface IChanges
    {
        [OperationContract]
        bool SubscribeToResultChange(int triggersolution, string pathId);

        [OperationContract]
        bool UnSubscribeToResultChange();
    }
}
