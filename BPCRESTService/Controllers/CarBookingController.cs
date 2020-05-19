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
    public class CarBookingController : ControllerBase
    {
        ManagerCarBooking manager = new ManagerCarBooking();

        // GET: api/CarBooking
        [HttpGet]
        public IEnumerable<CarBooking> Get()
        {
            return manager.GetAllCarBookings();
        }

        // GET: api/CarBooking/5
        [HttpGet("{id}", Name = "Get")]
        public CarBooking Get(int id)
        {
            return manager.GetCarBookingFromId(id);
        }

        // POST: api/CarBooking
        [HttpPost]
        public bool Post([FromBody] CarBooking value)
        {
            return manager.CreateCarBooking(value);
        }

        // PUT: api/CarBooking/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] CarBooking value)
        {
            return manager.UpdateCarBooking(value, id);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public CarBooking Delete(int id)
        {
            return manager.DeleteCarBooking(id);
        }
    }
}
