using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApi.Data;
using webApi.Models;

namespace webApi.Controllers.flatMasters
{
    [Produces("application/json")]
    [Route("api/flatMasters")]
    public class flatMastersController : Controller
    {
        private readonly MyDbContext _context;

        public flatMastersController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/flatMasters
        [HttpGet]
        public List<flatMaster> Get()
        {
            var flat = _context.flatMasters.Include(s => s.societyMaster).ToList();
            return (flat);
        }

        // GET: api/flatMasters/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetflatMaster([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var flatMaster = await _context.flatMasters.SingleOrDefaultAsync(m => m.flatNo == id);

            if (flatMaster == null)
            {
                return NotFound();
            }

            return Ok(flatMaster);
        }

        // PUT: api/flatMasters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutflatMaster([FromRoute] int id, [FromBody] flatMaster flatMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != flatMaster.flatNo)
            {
                return BadRequest();
            }

            _context.Entry(flatMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!flatMasterExists(id))
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

        // POST: api/flatMasters
        [HttpPost]
        public async Task<IActionResult> PostflatMaster([FromBody] flatMaster flat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.flatMasters.Add(flat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlat", new { id = flat.flatNo }, flat);
        }

        // DELETE: api/flatMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlat([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var flat = await _context.flatMasters.SingleOrDefaultAsync(m => m.flatNo == id);
            if (flat == null)
            {
                return NotFound();
            }

            _context.flatMasters.Remove(flat);
            await _context.SaveChangesAsync();

            return Ok(flat);
        }
        private bool flatMasterExists(int id)
        {
            return _context.flatMasters.Any(e => e.flatNo == id);
        }
    }
}