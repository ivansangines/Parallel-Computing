using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TSGALibrary
{
    [ServiceContract]
    interface IPathChanged
    {
        [OperationContract()]
        bool ChangePath(int bestPath, string pathId); //Method used to change the best path for a better one

    }
}
