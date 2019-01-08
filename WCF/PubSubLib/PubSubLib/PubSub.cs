using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace PubSubLib
{
    /*
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class PubSub : ILongCompute
    {
        ComputeResult cr = new ComputeResult();
        Object olock = new object();
        #region ILongCompute Members
        public void Compute(int a, int b, string clientId)
        {
            Thread.Sleep(5000);// asssume 5 secs to produce result
            lock (olock)
            {
                cr.Result = 45.667 + a + b;
                cr.ResultTime = DateTime.Now;
                cr.ClientID = clientId;
                // trigger callback in client
                IComputeCallback callbackChannel =
                OperationContext.Current.GetCallbackChannel<IComputeCallback>();
                if (((ICommunicationObject)callbackChannel).State ==
               CommunicationState.Opened)
                    callbackChannel.OnComputeResult(cr);
            }
            Thread.Sleep(5000); // 5 more secs to produce updated res
            lock (olock)
            {
                cr.Result = cr.Result + a + b;
                cr.ResultTime = DateTime.Now;
                cr.ClientID = clientId;
                //trigger callback in client
                IComputeCallback callbackChannel =

                OperationContext.Current.GetCallbackChannel<IComputeCallback>();
                if (((ICommunicationObject)callbackChannel).State ==
               CommunicationState.Opened)
                    callbackChannel.OnComputeResult(cr);
            }
        }
        #endregion
    }
    */

    //IMPLEMENTING ISTOCK AND IPRICECHANGE

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class PubSub : ILongCompute, IStocks, IPriceChange
    {
        static List<IStockCallback> SubscriberList = new List<IStockCallback>();

        ComputeResult cr = new ComputeResult();
        Object olock = new object();
        #region ILongCompute Members

        public void Compute(int a, int b, string clientId)
        {
            Thread.Sleep(5000);
            lock (olock)
            {
                cr.Result = 45.667 + a + b;
                cr.ResultTime = DateTime.Now;
                cr.ClientID = clientId;
                // trigger callback in client
                IComputeCallback callbackChannel = OperationContext.Current.GetCallbackChannel<IComputeCallback>();
                if (((ICommunicationObject)callbackChannel).State == CommunicationState.Opened)
                    callbackChannel.OnComputeResult(cr);
            }
            Thread.Sleep(5000);
            lock (olock)
            {
                cr.Result = cr.Result + a + b;
                cr.ResultTime = DateTime.Now;
                cr.ClientID = clientId;
                //trigger callback in client
                IComputeCallback callbackChannel = OperationContext.Current.GetCallbackChannel<IComputeCallback>();
                if (((ICommunicationObject)callbackChannel).State == CommunicationState.Opened)
                    callbackChannel.OnComputeResult(cr);
            }
        }
        #endregion
        #region IStocks Members
        public bool SubscribeToStockPrice(string stocksym, double triggerPrice)
        {
          
        try
            {
                IStockCallback callbackChannel = OperationContext.Current.GetCallbackChannel<IStockCallback>();
                if (SubscriberList.Contains(callbackChannel) == false)
                {
                    SubscriberList.Add(callbackChannel);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message, new FaultCode("Subscription Error"));
            }
            return true;
        }
        public bool UnSubscribeToStockPrice(string stocksym)
        {
            try
            {
                IStockCallback callbackChannel = OperationContext.Current.GetCallbackChannel<IStockCallback>();
                if (SubscriberList.Contains(callbackChannel) == true)
                {
                    SubscriberList.Remove(callbackChannel);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message, new FaultCode("UnSubscription Error"));
            }
            return true;
        }

        #endregion
        #region IPriceChange Members
        public bool ChangeStockPrice(string symbol, double newprice)
        {
            try
            {
                if ((symbol == "IBM") && (newprice > 120)) //subscription trigger???
                {
                    // trigger call to the subscribers
                    foreach (IStockCallback icbChannel in SubscriberList)
                    {
                        StockInfo si = new StockInfo();
                        si.Price = newprice;
                        si.Symbol = symbol;
                        si.STime = DateTime.Now;
                        if (((ICommunicationObject)icbChannel).State == CommunicationState.Opened)
                            icbChannel.OnPriceChange(si);
                    }
                }
            }
            catch (Exception ex)
            {
               
            throw new FaultException(ex.Message, new FaultCode("Change Price Error"));
            }
            return true;
        }
        #endregion
    }
}
