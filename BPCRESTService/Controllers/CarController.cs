using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPCClassLibrary;
using BPCRESTService.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BPCRESTService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ManagerCar manager = new ManagerCar(); 

        // GET: api/Car
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return manager.GetAllCars();
        }

        // GET: api/Car/5
        [HttpGet("{id}", Name = "GetCar")]
        public Car Get(int id)
        {
            return manager.GetCarFromName(id);
        }

        // POST: api/Car
        [HttpPost]
        public bool Post([FromBody] Car value)
        {
            return manager.CreateCar(value);
        }

        // PUT: api/Car/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Car value)
        {
            return manager.UpdateCar(value, id);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Car Delete(int id)
        {
            return manager.DeleteCar(id);
        }
    }
}
