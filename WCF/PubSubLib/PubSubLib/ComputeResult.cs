using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PubSubLib
{
    [DataContract]
    public class ComputeResult
    {
        double result;
        [DataMember]
        public double Result
        {
            get { return result; }
            set { result = value; }
        }
        DateTime resultTime;
        [DataMember]
        public DateTime ResultTime
        {
            get { return resultTime; }
            set { resultTime = value; }
        }
        string clientID;
        [DataMember]
        public string ClientID
        {
            get { return clientID; }
            set { clientID = value; }
        }
    }

}
