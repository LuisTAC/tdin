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
    [ServiceBehavior(ConcurrencyMode =ConcurrencyMode.Reentrant)]
    public class StockService : IStockDirectory
    {
        private int LastCallbackId = 0;
        private Dictionary<int, IStockServiceCallback> CallbacksIds;
        private Dictionary<int, HashSet<IStockServiceCallback>> OnOrderStatusChangeCallbacks;
        private HashSet<IStockServiceCallback> OnNewOrderCallbacks;

        public StockService()
        {
            this.CallbacksIds = new Dictionary<int, IStockServiceCallback>();
            this.OnOrderStatusChangeCallbacks = new Dictionary<int, HashSet<IStockServiceCallback>>();
            this.OnNewOrderCallbacks = new HashSet<IStockServiceCallback>();
        }

        public StockServiceContracts.StockOrder OrderStock(string company, int quantity, StockServiceContracts.StockOrder.OrderType type, string email)
        {
            Console.WriteLine("Received request!");

            using(StockServiceModelContainer database = new StockServiceModelContainer())
            {
                database.Database.Connection.Open();

                StockOrder toAdd = new StockOrder()
                {
                    Company = company,
                    Quantity = quantity,
                    Email = email,
                    RequestDate = DateTime.UtcNow.ToString(),
                    Type = this.GetOrderTypeFromEnum(type, database)
                };

                Console.WriteLine("Created Order!");

                try
                {
                    toAdd = database.StockOrders.Add(toAdd);
                    database.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new FaultException<StockServiceFault>(new StockServiceFault(e.Message));
                }

                StockServiceContracts.StockOrder createdOrder = StockService.ToContractStockOrder(toAdd);
                this.FireOnNewOrder(createdOrder);

                return createdOrder;
            }
        }

        public void ExecuteOrder(int id, float stockValue)
        {
            using (StockServiceModelContainer database = new StockServiceModelContainer())
            {
                StockOrder order = database.StockOrders.Find(id);
                if (order == null)
                    throw new FaultException<OrderNotFoundFault>(new OrderNotFoundFault(id));

                try
                {
                    order.StockValue = stockValue;
                    order.ExecutionDate = DateTime.UtcNow.ToString();
                    database.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new FaultException<StockServiceFault>(new StockServiceFault(e.Message));
                }

                StockServiceContracts.StockOrder updatedOrder = StockService.ToContractStockOrder(order);
                this.FireOnOrderStatusChange(updatedOrder);
            }
        }

        public IEnumerable<StockServiceContracts.StockOrder> GetAllOrders()
        {
            using (StockServiceModelContainer database = new StockServiceModelContainer())
            {
                return database.StockOrders
                    .Select(StockService.ToContractStockOrder)
                    .ToList<StockServiceContracts.StockOrder>();
            }
        }

        public IEnumerable<StockServiceContracts.StockOrder> GetClientOrders(string clientEmail)
        {
            using(StockServiceModelContainer database = new StockServiceModelContainer())
            {
                return database.StockOrders
                    .Where(s => s.Email == clientEmail)
                    .Select(StockService.ToContractStockOrder)
                    .ToList<StockServiceContracts.StockOrder>();
            }
        }

        public int RegisterOnNewOrder()
        {
            IStockServiceCallback callback = OperationContext.Current.GetCallbackChannel<IStockServiceCallback>();
            Console.WriteLine("Someone registered for a new order!");

            int callbackId = Interlocked.Increment(ref this.LastCallbackId);
            this.CallbacksIds.Add(callbackId, callback);
            this.OnNewOrderCallbacks.Add(callback);

            return callbackId;
        }

        public int RegisterOnOrderStatusChange(int id)
        {
            IStockServiceCallback callback = OperationContext.Current.GetCallbackChannel<IStockServiceCallback>();
            Console.WriteLine("Someone registered for an order status change!");

            using (StockServiceModelContainer database = new StockServiceModelContainer())
            {
                StockOrder order = database.StockOrders.Find(id);
                if (order == null)
                    throw new FaultException<OrderNotFoundFault>(new OrderNotFoundFault(id));

                int callbackId = Interlocked.Increment(ref this.LastCallbackId);
                this.CallbacksIds.Add(callbackId, callback);

                if (this.OnOrderStatusChangeCallbacks.ContainsKey(id) == false)
                    this.OnOrderStatusChangeCallbacks[id] = new HashSet<IStockServiceCallback>();

                this.OnOrderStatusChangeCallbacks[id].Add(callback);

                return callbackId;
            }
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

        private void FireOnNewOrder(StockServiceContracts.StockOrder order)
        {
            List<IStockServiceCallback> callbacksToRemove = new List<IStockServiceCallback>();

            foreach (IStockServiceCallback callback in this.OnNewOrderCallbacks)
            {
                try
                {
                    callback.OnNewOrder(order);
                } catch(Exception e)
                {
                    Console.WriteLine("Could not access a callback: " + e.Message + ".");
                    Console.WriteLine("Removing it to avoid more errors...");
                    callbacksToRemove.Add(callback);
                }
            }

            foreach (IStockServiceCallback failingCallback in callbacksToRemove)
                this.OnNewOrderCallbacks.Remove(failingCallback);
        }

        private void FireOnOrderStatusChange(StockServiceContracts.StockOrder updatedOrder)
        {
            if (this.OnOrderStatusChangeCallbacks.ContainsKey(updatedOrder.Id))
            {
                HashSet<IStockServiceCallback> callbacks = this.OnOrderStatusChangeCallbacks[updatedOrder.Id];
                if (callbacks != null)
                {
                    List<IStockServiceCallback> callbacksToRemove = new List<IStockServiceCallback>();

                    foreach (IStockServiceCallback callback in callbacks) {
                        try
                        {
                            callback.OnOrderStatusChange(updatedOrder);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Could not access a callback: " + e.Message + ".");
                            Console.WriteLine("Removing it to avoid more errors...");
                            callbacksToRemove.Add(callback);
                        }
                    }

                    foreach (IStockServiceCallback failingCallback in callbacksToRemove)
                        callbacks.Remove(failingCallback);
                }
            }
        }

        private OrderType GetOrderTypeFromEnum(StockServiceContracts.StockOrder.OrderType orderType, StockServiceModelContainer database)
        {
            if (orderType == StockServiceContracts.StockOrder.OrderType.Purchase)
                return database.OrderTypes.First(o => o.Name.Equals("Purchase"));
            else
                return database.OrderTypes.First(o => o.Name.Equals("Sale"));
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
    }
}
