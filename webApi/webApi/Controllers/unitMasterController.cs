using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApi.Models;

namespace webApi.Controllers
{
   
    [Produces("application/json")]
    [Route("api/unitMaster")]
    public class unitMasterController : Controller
    {
        private readonly AdminDbContext _context;

        public unitMasterController(AdminDbContext context)
        {
            _context = context;
        }

        // GET: api/unitMaster
        [HttpGet]
        public List<unitMaster> Get()
        {
            var admn = _context.unitMasters.ToList();
            return (admn);
        }

        // GET: api/unitMaster/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/unitMaster
        [HttpPost]
        public IActionResult unitMaster([FromBody]unitMaster obj)

        {
            _context.unitMasters.Add(obj);
            _context.SaveChanges();
            return new ObjectResult("Unit Added Successfully");

        }


        // PUT: api/unitMaster/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
