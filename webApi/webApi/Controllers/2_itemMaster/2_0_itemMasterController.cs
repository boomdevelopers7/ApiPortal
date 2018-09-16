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
            var item = _context.ItemMasters.Include(s=>s.unitMaster).ToList();
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
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/itemMaster/5
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
