using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApi.Data;
using webApi.Models;

namespace webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/areaMaster")]
    public class areaMasterController : Controller
    {

        private readonly MyDbContext _context;

        public areaMasterController(MyDbContext context)
        {
            _context = context;
        }
        // GET: api/areaMaster
        [HttpGet]
        public List<areaMaster> Get()
        {
            var area = _context.areaMasters.Include(s => s.cityMaster).ToList();
            return (area);
        }

        // GET: api/areaMaster/5
        [HttpGet("{id}", Name = "areaGet")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/areaMaster
        [HttpPost]
        public IActionResult areaMaster([FromBody]areaMaster obj)

        {
            if (obj.areaId != 0)
            {
                _context.areaMasters.Attach(obj);
                _context.areaMasters.Update(obj);
            }
            else
            _context.areaMasters.Add(obj);
            _context.SaveChanges();
            return new ObjectResult("Type Added Successfully");
        }

        // PUT: api/areaMaster/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var area = _context.areaMasters.SingleOrDefault(m => m.areaId == id);
            if (area == null)
            {
                return NotFound();
            }
            _context.areaMasters.Remove(area);
            _context.SaveChanges();
            return Ok(area);
        } 
    }
}
