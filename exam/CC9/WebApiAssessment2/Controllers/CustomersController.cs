using System.Linq;
using System.Web.Http;
using WebApiAssessment2.Models;

namespace WebApiAssessment2.Controllers
{
    public class CustomersController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();

        // GET: api/customers
        [HttpGet]
        [Route("api/customers/by-country/{country}")]
        public IHttpActionResult GetCustomersByCountry(string country)
        {
            var data = db.GetCustomersByCountry(country).ToList();
            return Ok(data);
        }
    }
}
