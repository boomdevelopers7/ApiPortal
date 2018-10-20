using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApi.Data;
using webApi.Models;



namespace webApi.Controllers._6_CityMaster
{
    [Produces("application/json")]
    [Route("api/cityMaster")]
    public class cityMasterController : Controller
    {
        private readonly MyDbContext _context;

        public cityMasterController(MyDbContext context)
        {
            _context = context;
        }
        // GET: api/cityMaster
        [HttpGet]
        public List<cityMaster> Get()
        {
            var listCity = _context.cityMaster.Where(s => s.isActive == true).ToList();
            return (listCity);
        }

        // GET: api/cityMaster/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        [HttpPost]
        public IActionResult cityMaster([FromBody] cityMaster obj)
        {
            obj.isActive = true;
            if (obj.cityId != 0)
            {
                _context.cityMaster.Attach(obj);
                _context.cityMaster.Update(obj);
            }
            else
            {
                _context.cityMaster.Add(obj);
            }
            _context.SaveChanges();
            return new ObjectResult("city Added Successfully");

        }
        // PUT: api/cityMaster/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.cityMaster.SingleOrDefault(m => m.cityId == id);
            if (item == null)
            {
                return NotFound();
            }
            item.isActive = false;
            _context.cityMaster.Update(item);
            _context.SaveChanges();
            return Ok(item);
        }
    }
}
