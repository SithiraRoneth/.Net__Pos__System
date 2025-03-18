using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS_System.Model;
using System.Net;
using System.Xml.Linq;

namespace POS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        static private List<Customer> customers = new List<Customer>
        {
            new Customer
            {
                Id = 1,
                Name = "Sithira",
                Address = "Thalahena",
                Contact = "0704068026"
            },
            new Customer
            {
               Id = 2,
               Name = "Roneth",
               Address = "Colombo",
               Contact = "0706068026"
            }
        };
        [HttpGet]
        public ActionResult<List<Customer>> GetCustomers()
        {
            return Ok(customers);
        }
    }
}
