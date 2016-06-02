using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockServiceWebClient.Models
{
    public class Order
    {
        public int id { get; set; }
        public double stock_value { get; set; }
        public string email { get; set; }
        public string companyName { get; set; }
        public int amount { get; set; }
        public StockService.StockOrder.OrderType type { get; set; }
        public string RequestDate { get; set; }
        public string ExecutionDate { get; set; }
    }
}