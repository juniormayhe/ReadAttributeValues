using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Shared;
using Application.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace InterceptionByAttribute.WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IRepository repository;

        public CustomersController(IRepository repository)
        {
            this.repository = repository;
        }

        // GET api/values
        [HttpGet("location/{locationId}")]
        public ActionResult<IEnumerable<Customer>> GetByLocation(int locationId)
        {
            var list = repository.GetCustomers(locationId);
            return list.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
