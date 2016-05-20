using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StockServiceContracts
{
    [DataContract]
    public class StockOrder
    {
        public enum OrderType
        {
            Purchase, Sale
        }

        public enum OrderState
        {
            Pending, Executed
        }

        [DataMember]
        public int Id;

        [DataMember]
        public object Client;

        [DataMember]
        public string Email;

        [DataMember]
        public OrderType Type;

        [DataMember]
        public int Quantity;

        [DataMember]
        public string Company;

        [DataMember]
        public string RequestDate;

        [DataMember]
        public string ExecutionDate;

        [DataMember]
        public float StockValue;

        [DataMember]
        public float TotalValue;

        [DataMember]
        public OrderState State;

    }
}
