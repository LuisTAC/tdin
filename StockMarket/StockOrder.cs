using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StockServiceContracts
{
    [DataContract]
    public class StockOrder : ICloneable
    {
        public enum OrderType
        {
            Purchase, Sale
        }

        [DataMember]
        public int Id;

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

        public bool IsPending()
        {
            return this.ExecutionDate == null;
        }

        public float GetTotalValue()
        {
            if (this.IsPending())
                return -1;
            else
                return this.Quantity * this.StockValue;
        }

        public DateTime GetRequestDateTime()
        {
            return DateTime.Parse(this.RequestDate);
        }

        public DateTime GetExecutioDate()
        {
            return DateTime.Parse(this.ExecutionDate);
        }

        public object Clone()
        {
            return new StockOrder()
            {
                Id = this.Id,
                Email = this.Email,
                Type = this.Type,
                Quantity = this.Quantity,
                Company = this.Company,
                RequestDate = this.RequestDate,
                ExecutionDate = this.ExecutionDate,
                StockValue = this.StockValue
            };
        }

        
    }
}
