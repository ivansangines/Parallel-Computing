using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PubSubLib
{
    interface IStockCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnPriceChange(StockInfo sinfo);
    }

    [ServiceContract(CallbackContract = typeof(IStockCallback))]
    public interface IStocks
    {
        [OperationContract]
        bool SubscribeToStockPrice(string stocksym, double triggerPrice);
        [OperationContract]
        bool UnSubscribeToStockPrice(string stocksym);
    }

}
