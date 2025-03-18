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

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            var customer = customers.FirstOrDefault(c => c.Id == id);
            if(customer is null)
                return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public ActionResult<Customer> AddCustomer(Customer cus)
        {
            if (cus is null)
                return BadRequest();
            cus.Id = customers.Max(c => c.Id) + 1;
            customers.Add(cus);
            return CreatedAtAction(nameof(GetCustomerById), new { id = cus.Id }, cus);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(int id, Customer updatedCustomer)
        {
            var customer = customers.FirstOrDefault(c => c.Id == id);
            if (updatedCustomer is null)
                return NotFound();

            customer.Name = updatedCustomer.Name;
            customer.Address = updatedCustomer.Address;
            customer.Contact = updatedCustomer.Contact;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            var customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer is null)
                return NotFound();

            customers.Remove(customer);
            return NoContent();
        }
    }
}
