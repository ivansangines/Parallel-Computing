using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TSGAMT2010
{
    class TSGAClient : PS.IChangesCallback, IDisposable
    {
        PS.ChangesClient proxy = null;


        #region IChanges Members

        public void SubscribeToResultChange(int triggersolution, string pathId)
        {
            try
            {
                proxy = new PS.ChangesClient(new System.ServiceModel.InstanceContext(this), "CHEP"); //CHEP is the endpoint name for IChanges interface ep 

                proxy.SubscribeToResultChange(triggersolution, pathId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void UnSubscribeToResultChange()
        {
            try
            {
                if (proxy != null)
                    proxy.UnSubscribeToResultChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region IChangeCallBack Members
        public void OnBestPathChange(PS.TSGAInfo sinfo)
        {

            MessageBox.Show("Best final Path changed: Best Path:" + sinfo.BestPath);

        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            proxy.Close();
        }
        #endregion
    }
}
