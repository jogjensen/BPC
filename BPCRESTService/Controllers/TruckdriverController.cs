using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPCClassLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BPCRESTService.Managers;

namespace BPCRESTService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckdriverController : ControllerBase
    {
        ManagerTruckdriver manager = new ManagerTruckdriver();

        // GET: api/Truckdriver
        [HttpGet]
        public IEnumerable<Truckdriver> Get()
        {
            return manager.GetAllTruckdrivers();
        }

        // GET: api/Truckdriver/5
        [HttpGet("{id}", Name = "GetTruckdriver")]
        public Truckdriver Get(int id)
        {
            return manager.GetDriverFromId(id);
        }

        // POST: api/Truckdriver
        [HttpPost]
        public bool Post([FromBody] Truckdriver value)
        {
            return manager.CreateDriver(value);
        }

        // PUT: api/Truckdriver/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Truckdriver value)
        {
            return manager.UpdateTruckdriver(value, id);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Truckdriver Delete(int id)
        {
            return manager.DeleteDriver(id);
        }
    }
}
