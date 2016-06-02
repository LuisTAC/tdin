using StockServiceWebClient.Models;
using StockServiceWebClient.StockService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockServiceWebClient.Controllers
{
    public class SubmitOrderController : Controller
    {
        private StockService.StockDirectoryClient proxy = new StockService.StockDirectoryClient();

        // GET: SubmitOrder
        public ActionResult Index()
        {
            return View();
        }

        // GET: Welcome
        public ActionResult Welcome()
        {
            return View();
        }

        // POST: AddStockOrder
        [HttpPost]
        public ActionResult AddStockOrder(Order order)
        {
            proxy.OrderStock(order.companyName, order.amount, order.type, order.email);
            return View();
        }
    }
}