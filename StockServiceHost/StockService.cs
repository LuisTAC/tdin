using StockServiceContracts;
using System;
using System.Collections.Generic;

namespace StockServiceHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class StockService : IStockDirectory
    {
        public void ExecuteOrder(int id, float stockValue)
        {
            Console.WriteLine("Received an order execution request!");
        }

        public IEnumerable<StockOrder> GetClientHistory()
        {
            throw new NotImplementedException();
        }

        public StockOrder.OrderState GetOrderStatus(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StockOrder> GetPendingOrders()
        {
            throw new NotImplementedException();
        }

        public StockOrder OrderStock(string company, int quantity, StockOrder.OrderType type)
        {
            throw new NotImplementedException();
        }
    }
}
