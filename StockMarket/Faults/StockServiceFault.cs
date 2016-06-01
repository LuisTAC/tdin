using System.Runtime.Serialization;

namespace StockMarket.Faults
{
    [DataContract]
    public class StockServiceFault
    {
        public readonly string Message;

        public StockServiceFault(string message)
        {
            this.Message = message;
        }
    }
}
