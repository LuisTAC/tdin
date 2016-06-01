using StockMarket;
using StockMarket.Faults;
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
        [OperationContract(IsOneWay = false)]
        [FaultContract(typeof(StockServiceFault))]
        StockOrder OrderStock(string company, int quantity, StockOrder.OrderType type);

        [OperationContract(IsOneWay = true)]
        [FaultContract(typeof(OrderNotFoundFault))]
        void ExecuteOrder(int id, float stockValue);

        [OperationContract(IsOneWay = false)]
        [FaultContract(typeof(StockServiceFault))]
        IEnumerable<StockOrder> GetAllOrders();

        [OperationContract(IsOneWay = false)]
        [FaultContract(typeof(StockServiceFault))]
        IEnumerable<StockOrder> GetClientOrders(string clientEmail);

        [OperationContract(IsOneWay = false)]
        int RegisterOnNewOrder(IStockServiceCallback callback);

        [OperationContract(IsOneWay = false)]
        [FaultContract(typeof(OrderNotFoundFault))]
        int RegisterOnOrderStatusChange(int id, IStockServiceCallback callback);

        [OperationContract(IsOneWay = true)]
        void UnregisterOnNewOrder(int callbackId);

        [OperationContract(IsOneWay = true)]
        void UnregisterOnOrderStatusChange(int orderId, int callbackId);
    }
}
