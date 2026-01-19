using MVCApplication_Assessment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCApplication_Assessment.Controllers
{
    public class CodeController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        // Action 1: Customers in Germany
        public ActionResult CustomersInGermany()
        {
            var customers = db.Customers
                              .Where(c => c.Country == "Germany")
                              .ToList();
            return View(customers);
        }

        // Action 2: Customer details with OrderId == 10248
        public ActionResult CustomerByOrder()
        {
            var order = db.Orders
                          .Where(o => o.OrderID == 10248)
                          .Select(o => o.Customer)
                          .FirstOrDefault();

            return View(order);
        }
    }
}
