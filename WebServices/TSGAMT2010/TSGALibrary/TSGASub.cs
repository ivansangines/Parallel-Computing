using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TSGALibrary
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class TSGASub : IChanges, IPathChanged
    {
        static List<IChangeCallBack> SubscriberList = new List<IChangeCallBack>();
        static TSGAInfo bestInfo;

        #region IPathChanged Members

        public bool ChangePath(int bestPath, string pathId)
        {
            if (bestInfo == null)
            {
                bestInfo = new TSGAInfo();
                bestInfo.BestPath = bestPath;
                bestInfo.PathId = pathId;
            }
            try
            {
                // trigger call to the subscribers
                foreach (IChangeCallBack icbChannel in SubscriberList)
                {
                    TSGAInfo si = new TSGAInfo();
                    si.BestPath = bestPath;
                    si.PathId = pathId;
                    if (((ICommunicationObject)icbChannel).State == CommunicationState.Opened)
                    {
                        //Checking if the current solution is better than the best obtained before
                        if (bestPath < bestInfo.BestPath)
                        {
                            //callback if the best path is changed
                            icbChannel.OnBestPathChange(si);
                            bestInfo.BestPath = si.BestPath;
                            bestInfo.PathId = si.PathId;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw new FaultException(ex.Message, new FaultCode("Change Path Error"));
            }
            return true;
        }
        #endregion

        #region IChanges Members
        public bool UnSubscribeToResultChange()
        {
            try
            {
                IChangeCallBack callbackChannel = OperationContext.Current.GetCallbackChannel<IChangeCallBack>();
                if (SubscriberList.Contains(callbackChannel) == true)
                {
                    SubscriberList.Remove(callbackChannel);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message, new
               FaultCode("UnSubscription Error"));
            }

            return true;
        }

        public bool SubscribeToResultChange(int triggersolution, string pathId)
        {
            try
            {
                IChangeCallBack callbackChannel = OperationContext.Current.GetCallbackChannel<IChangeCallBack>();
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
        #endregion

    }
}
