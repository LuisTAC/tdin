using StockServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
    public interface IStockServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnNewOrder(StockOrder order);

        [OperationContract(IsOneWay = true)]
        void OnOrderStatusChange(StockOrder order);

    }
}
