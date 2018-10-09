using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApi.Data;
using webApi.Models;

namespace webApi.Controllers.customerMasters
{
    [Produces("application/json")]
    [Route("api/customerMasters")]
    public class customerMastersController : Controller
    {
        private readonly MyDbContext _context;

        public customerMastersController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/customerMasters
        [HttpGet]
        public List<customerMaster> Get()
        {
            var customer = _context.customerMasters.Include(s => s.flat).ToList();
            return (customer);
        }

        // GET: api/customerMasters/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetcustomerMaster([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customerMaster = await _context.customerMasters.SingleOrDefaultAsync(m => m.custId == id);

            if (customerMaster == null)
            {
                return NotFound();
            }

            return Ok(customerMaster);
        }

        // PUT: api/customerMasters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutcustomerMaster([FromRoute] int id, [FromBody] customerMaster customerMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerMaster.custId)
            {
                return BadRequest();
            }

            _context.Entry(customerMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!customerMasterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/customerMasters
        [HttpPost]
        public async Task<IActionResult> PostcustomerMaster([FromBody] customerMaster cust)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.customerMasters.Add(cust);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlat", new { id = cust.flatNo }, cust);
        }

        // DELETE: api/customerMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecustomer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cust = await _context.customerMasters.SingleOrDefaultAsync(m => m.custId == id);
            if (cust == null)
            {
                return NotFound();
            }

            _context.customerMasters.Remove(cust);
            await _context.SaveChangesAsync();

            return Ok(cust);
        }
        private bool customerMasterExists(int id)
        {
            return _context.customerMasters.Any(e => e.custId == id);
        }
    }
}