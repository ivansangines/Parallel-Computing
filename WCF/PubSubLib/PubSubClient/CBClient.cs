using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PubSubClient
{
    class CBClient : PS.ILongComputeCallback, IDisposable
    {
        PS.LongComputeClient proxy = null;

        public void CallLongCompute(int x, int y, string clientID)
        {
            try
            {
                proxy = new PS.LongComputeClient(new System.ServiceModel.InstanceContext(this),"PSEP");
                proxy.Compute(x, y, clientID);
            }
            catch (Exception ex)
            {
            throw ex;
            }
        }

        #region ILongComputeCallback Members
        public void OnComputeResult(PS.ComputeResult res)
        {
            MessageBox.Show(res.Result.ToString() + "\n" + res.ClientID);
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
