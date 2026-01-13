using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Application.Models;


namespace MVC_Application.Controllers
{
    namespace YourNamespace.Controllers
    {
        public class CodeController : Controller
        {
            private NorthwindEntities db = new NorthwindEntities();

            // Action 1: 
            public ActionResult CustomersInGermany()
            {
                var customers = db.Customers
                                  .Where(c => c.Country == "Germany")
                                  .ToList();

                return View(customers);
            }

            // Action 2:
            public ActionResult CustomerByOrder()
            {
                var customer = db.Orders
                                 .Where(o => o.OrderID == 10248)
                                 .Select(o => o.Customer)
                                 .FirstOrDefault();

                return View(customer);
            }
        }
    }
}
