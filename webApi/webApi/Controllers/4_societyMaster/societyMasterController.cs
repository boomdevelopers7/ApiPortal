﻿using System;
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
            var society = _context.societyMasters.Include(s => s.areaMaster).Where(s => s.isActive == true).ToList();
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
            obj.isActive = true;
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
            var item = _context.societyMasters.SingleOrDefault(m => m.societyId == id);
            if (item == null)
            {
                return NotFound();
            }
            item.isActive = false;
            _context.societyMasters.Update(item);
            _context.SaveChanges();
            return Ok(item);
        }
    }
}
