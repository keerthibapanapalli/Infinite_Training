using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Application.Models
{

    public class OrderVM
    {
        public int OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public string CustomerID { get; set; }
        public string ShipCountry { get; set; }
    }
}