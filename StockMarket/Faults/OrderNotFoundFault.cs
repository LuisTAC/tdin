using System.Runtime.Serialization;

namespace StockMarket.Faults
{
    [DataContract]
    public class OrderNotFoundFault : StockServiceFault
    {
        public readonly int OrderId;

        public OrderNotFoundFault(int id) : base("There is no order with the id " + id + "!") {
            this.OrderId = id;
        }
    }
}
