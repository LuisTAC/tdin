using StockMarket.Faults;
using StockServiceContracts;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Linq;
using StockMarket;
using System.Threading;

namespace StockServiceHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class StockService : IStockDirectory
    {
        private int LastCallbackId = 0;
        private Dictionary<int, IStockServiceCallback> CallbacksIds;
        private Dictionary<int, HashSet<IStockServiceCallback>> OnOrderStatusChangeCallbacks;
        private HashSet<IStockServiceCallback> OnNewOrderCallbacks;
        
        private StockServiceModelContainer database;

        public StockService()
        {
            this.database = new StockServiceModelContainer();
            this.CallbacksIds = new Dictionary<int, IStockServiceCallback>();
            this.OnOrderStatusChangeCallbacks = new Dictionary<int, HashSet<IStockServiceCallback>>();
            this.OnNewOrderCallbacks = new HashSet<IStockServiceCallback>();
        }

        public StockServiceContracts.StockOrder OrderStock(string company, int quantity, StockServiceContracts.StockOrder.OrderType type)
        {
            throw new NotImplementedException();
        }

        public void ExecuteOrder(int id, float stockValue)
        {
            StockOrder order = this.database.StockOrders.Find(id);
            if (order == null)
                throw new FaultException<OrderNotFoundFault>(new OrderNotFoundFault(id));

            try
            {
                order.StockValue = stockValue;
                this.database.SaveChanges();
            } catch(Exception e)
            {
                throw new FaultException<StockServiceFault>(new StockServiceFault(e.Message));
            }
        }

        public IEnumerable<StockServiceContracts.StockOrder> GetAllOrders()
        {
            return from stockOrder in this.database.StockOrders
                   select StockService.ToContractStockOrder(stockOrder);
        }

        public IEnumerable<StockServiceContracts.StockOrder> GetClientOrders(string clientEmail)
        {
            return from stockOrder in database.StockOrders
                   where stockOrder.Email == clientEmail
                   select StockService.ToContractStockOrder(stockOrder);
        }

        public int RegisterOnNewOrder(IStockServiceCallback callback)
        {
            int callbackId = Interlocked.Increment(ref this.LastCallbackId);
            this.CallbacksIds.Add(callbackId, callback);
            this.OnNewOrderCallbacks.Add(callback);

            return callbackId;
        }

        public int RegisterOnOrderStatusChange(int id, IStockServiceCallback callback)
        {
            StockOrder order = this.database.StockOrders.Find(id);
            if (order == null)
                throw new FaultException<OrderNotFoundFault>(new OrderNotFoundFault(id));

            int callbackId = Interlocked.Increment(ref this.LastCallbackId);
            this.CallbacksIds.Add(callbackId, callback);

            if (this.OnOrderStatusChangeCallbacks.ContainsKey(id) == false)
                this.OnOrderStatusChangeCallbacks[id] = new HashSet<IStockServiceCallback>();

            this.OnOrderStatusChangeCallbacks[id].Add(callback);

            return callbackId;
        }

        private static StockServiceContracts.StockOrder ToContractStockOrder(StockOrder order)
        {
            if (order == null)
                return null;

            return new StockServiceContracts.StockOrder()
            {
                Id = order.Id,
                Email = order.Email,
                Company = order.Company,
                Quantity = order.Quantity,
                RequestDate = order.RequestDate,
                ExecutionDate = order.ExecutionDate,
                StockValue = (float)order.StockValue,
                Type = StockService.FromOrderTypeString(order.Type.Name)
            };
        }

        private static StockServiceContracts.StockOrder.OrderType FromOrderTypeString(string orderType)
        {
            if (orderType.Equals("Purchase"))
                return StockServiceContracts.StockOrder.OrderType.Purchase;
            else
                return StockServiceContracts.StockOrder.OrderType.Sale;
        }

        public void UnregisterOnNewOrder(int callbackId)
        {
            if(this.CallbacksIds.ContainsKey(callbackId))
            {
                IStockServiceCallback callback = this.CallbacksIds[callbackId];
                if (this.OnNewOrderCallbacks.Contains(callback))
                    this.OnNewOrderCallbacks.Remove(callback);
            }
        }

        public void UnregisterOnOrderStatusChange(int orderId, int callbackId)
        {
            if(this.CallbacksIds.ContainsKey(callbackId))
            {
                IStockServiceCallback callback = this.CallbacksIds[callbackId];
                IEnumerable<HashSet<IStockServiceCallback>> statusChangeCallbacks = this.OnOrderStatusChangeCallbacks.Values
                                                                            .Where(callbacks => callbacks.Contains(callback));

                foreach (HashSet<IStockServiceCallback> callbacks in statusChangeCallbacks)
                    callbacks.Remove(callback);
            }
        }
    }
}
