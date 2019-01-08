using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PubSubClient
{
    class STKClient : PS.IStocksCallback, IDisposable
    {
        PS.StocksClient stkProxy = null;
        int myId = 0;

        public void SubscribeToPriceChange(string sym, double triggerPrice, int id)
        {
            try
            {
                myId = id;
                stkProxy = new PS.StocksClient(new System.ServiceModel.InstanceContext(this), "SPEP"); //SEP is the endpoint name for IStocks interface ep
                stkProxy.SubscribeToStockPrice(sym, triggerPrice);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UnSubscribeToPriceChange(string sym)
        {
            try
            {
                if (stkProxy != null)
                    stkProxy.UnSubscribeToStockPrice(sym);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        #region IStocksCallback Members
        public void OnPriceChange(PS.StockInfo sinfo)
        {
            MessageBox.Show("Price Change Notification Received (MyId = " + myId.ToString() + ")\n" +
                sinfo.Symbol + ":" + sinfo.Price.ToString());
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            stkProxy.Close();
        }
        #endregion

    }



}
