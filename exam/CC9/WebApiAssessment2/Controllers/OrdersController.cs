
using System.Linq;
using System.Web.Http;
using WebApiAssessment2.Models;

namespace WebApiAssessment2.Controllers
{
    public class OrdersApiController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();

        // GET: api/orders/employee/5
        [HttpGet]
        [Route("api/orders/employee/5")]
        public IHttpActionResult GetOrdersByEmployee(int id)
        {
            var data = db.Orders
                         .Where(o => o.EmployeeID == id)
                         .Select(o => new
                         {
                             o.OrderID,
                             o.OrderDate,
                             o.CustomerID,
                             o.ShipCountry
                         })
                         .ToList();

            return Ok(data);
        }
    }
}
