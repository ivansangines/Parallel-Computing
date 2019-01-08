﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace NewWCFHost
{
    class Program
    {
        static void Main(string[] args)
        {
            // Host always hosts the main class for the service
            // Host needs to expose end points so that a client can communicate
            // to it. Each end point is a unique combination of A B C
            // A = address, B = binding i.e., comm. Prot., C = Contract i.e. interface
            ServiceHost sh = new ServiceHost(typeof(FirstWcfService.MyMath));
            // rest of the configuration for exposing end points will come
            // from WCF Configuration Editor
            sh.Open(); // host is ready
            Console.WriteLine("Host is ready, listening on " +
            sh.Description.Endpoints[0].Address.ToString());
            Console.WriteLine("Hit Enter to stop..");
            Console.ReadLine();
            sh.Close();
        }
    }

}
