using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StockServiceContracts
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IStockDirectory
    {

        [OperationContract]
        StockOrder OrderStock(string company, int quantity, StockOrder.OrderType type);

        [OperationContract]
        StockOrder.OrderState GetOrderStatus(int id);

        [OperationContract]
        void ExecuteOrder(int id, float stockValue);

        [OperationContract]
        IEnumerable<StockOrder> GetPendingOrders();

        [OperationContract]
        IEnumerable<StockOrder> GetClientHistory();
       
    }
}
