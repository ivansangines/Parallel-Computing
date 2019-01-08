using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TSGALibrary
{
    [DataContract]
    public class TSGAInfo

    {
        int bestPath;
        [DataMember]
        public int BestPath
        {
            get { return bestPath; }
            set { bestPath = value; }
        }
        string pathId;
        [DataMember]
        public string PathId
        {
            get { return pathId; }
            set { pathId = value; }
        }

    }
}
