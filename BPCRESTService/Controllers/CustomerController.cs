using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BPCRESTService.Managers;
using BPCClassLibrary;

namespace BPCRESTService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        ManagerCustomer manager = new ManagerCustomer();

        // GET: api/Customer
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return manager.GetAllCustomers();
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "GetCustomer")]
        public Customer Get(int id)
        {
            return manager.GetCustomerFromId(id);
        }

        // POST: api/Customer
        [HttpPost]
        public bool Post([FromBody] Customer value)
        {
            return manager.CreateCustomer(value);
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Customer value)
        {
            return manager.UpdateCustomer(value, id);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Customer Delete(int id)
        {
            return manager.DeleteCustomer(id);
        }
    }
}
