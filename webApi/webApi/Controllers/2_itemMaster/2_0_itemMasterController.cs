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
    [Route("api/itemMaster")]
    public class itemMasterController : Controller
    {
        private readonly MyDbContext _context;
        public itemMasterController(MyDbContext context)
        {
            _context = context;
        }
        // GET: api/itemMaster
        [HttpGet]
        public List<ItemMaster> Get()
        {
            var item = _context.ItemMasters.Include(s=>s.unitMaster).Include(s=>s.typeMaster).Where(s => s.isActive == true).ToList();
            return (item);
        }

        // GET: api/itemMaster/5
        //[HttpGet("{id}", Name = "Get")]

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/itemMaster
        [HttpPost]
        public IActionResult itemMaster([FromBody]ItemMaster obj)

        {
            obj.isActive = true;
            if (obj.itemId != 0)
            {
                _context.ItemMasters.Attach(obj);
                _context.ItemMasters.Update(obj);


            }
            else
                _context.ItemMasters.Add(obj);
            _context.SaveChanges();
            return new ObjectResult("Unit Added Successfully");

        }


        // PUT: api/itemMaster/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context. ItemMasters.SingleOrDefault(m => m.itemId == id);
            if (item == null)
            {
                return NotFound();
            }
            item.isActive = false;
            _context. ItemMasters.Update(item);
            _context.SaveChanges();
            return Ok(item);
        }
    }
}
