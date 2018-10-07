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
    [Route("api/typeMaster")]
    public class typeMasterController : Controller
    {
        private readonly MyDbContext _context;

        public typeMasterController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/typeMaster
        [HttpGet]
        public List<typeMaster> Get()
        {
            var type = _context.typeMasters.ToList();
            return (type);
        }


        // GET: api/typeMaster/5
        [HttpGet("{id}", Name = "typeGet")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/typeMaster
        [HttpPost]
        public IActionResult  typeMaster([FromBody]typeMaster obj)

        {
            if (obj.typeId != 0)
            {
                _context. typeMasters.Attach(obj);
                _context. typeMasters.Update(obj);


            }
            else
            _context. typeMasters.Add(obj);
            _context.SaveChanges();
            return new ObjectResult("Type Added Successfully");

        }

        
        // PUT: api/typeMaster/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context. typeMasters.SingleOrDefault(m => m.typeId == id);
            if (item == null)
            {
                return NotFound();
            }
            _context. typeMasters.Remove(item);
            _context.SaveChanges();
            return Ok(item);
        }

    }
}
