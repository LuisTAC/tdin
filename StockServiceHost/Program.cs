using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace StockServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(StockServiceHost.StockService));
            host.Open();

            Console.WriteLine("Service open. Press <Enter> to terminate.");
            Console.ReadLine();

            host.Close();
        }
    }
}
