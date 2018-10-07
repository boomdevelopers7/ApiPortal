using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApi.Data;
using webApi.Models;

namespace webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/societyMaster")]
    public class societyMasterController : Controller
    {
        private readonly MyDbContext _context;

        public societyMasterController(MyDbContext context)
        {
            _context = context;
        }
        // GET: api/societyMaster
        [HttpGet]
        public List<societyMaster> Get()
        {
            var society = _context.societyMasters.ToList();
            return (society);
        }

        // GET: api/societyMaster/5
        [HttpGet("{id}", Name = "societyGet")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/societyMaster
        [HttpPost]
        public IActionResult societyMaster([FromBody]societyMaster obj)

        {
            if (obj.societyId != 0)
            {
                _context.societyMasters.Attach(obj);
                _context.societyMasters.Update(obj);


            }
            else
                _context.societyMasters.Add(obj);
            _context.SaveChanges();
            return new ObjectResult("Type Added Successfully");

        }

        // PUT: api/societyMaster/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var society = _context.societyMasters.SingleOrDefault(m => m.societyId == id);
            if (society == null)
            {
                return NotFound();
            }
            _context.societyMasters.Remove(society);
            _context.SaveChanges();
            return Ok(society);
        }
    }
}
