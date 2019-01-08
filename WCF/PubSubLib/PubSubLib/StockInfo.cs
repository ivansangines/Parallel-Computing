using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PubSubLib
{
    [DataContract]
    public class StockInfo
    {
        string symbol;
        [DataMember]
        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }
        double price;
        [DataMember]
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        DateTime sTime;
        [DataMember]
        public DateTime STime
        {
            get { return sTime; }
            set { sTime = value; }
        }
    }

}
