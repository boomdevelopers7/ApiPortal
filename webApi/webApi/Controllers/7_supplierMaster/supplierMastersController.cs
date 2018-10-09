using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApi.Data;
using webApi.Models;

namespace webApi.Controllers.supplierMasters
{
    [Produces("application/json")]
    [Route("api/supplierMasters")]
    public class supplierMastersController : Controller
    {
        private readonly MyDbContext _context;

        public supplierMastersController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/supplierMasters
        [HttpGet]
        public List<supplierMaster> Get()
        {
            var admn = _context.supplierMasters.ToList();
            return (admn);
        }

        // GET: api/supplierMasters/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetsupplierMaster([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supplierMaster = await _context.supplierMasters.SingleOrDefaultAsync(m => m.supId == id);

            if (supplierMaster == null)
            {
                return NotFound();
            }

            return Ok(supplierMaster);
        }

        // PUT: api/supplierMasters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutsupplierMaster([FromRoute] int id, [FromBody] supplierMaster supplierMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != supplierMaster.supId)
            {
                return BadRequest();
            }

            _context.Entry(supplierMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!supplierMasterExists(id))
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

        // POST: api/supplierMasters
        [HttpPost]
        [HttpPost]
        public IActionResult suplierMasters([FromBody]supplierMaster obj)

        {
            if (obj.supId != 0)
            {
                _context.supplierMasters.Attach(obj);
                _context.supplierMasters.Update(obj);


            }
            else
                _context.supplierMasters.Add(obj);
            _context.SaveChanges();
            return new ObjectResult("Supplier Added Successfully");

        }

        // DELETE: api/suppliers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletesupplierMaster([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supplier = await _context.supplierMasters.SingleOrDefaultAsync(m => m.supId == id);
            if (supplier == null)
            {
                return NotFound();
            }

            _context.supplierMasters.Remove(supplier);
            await _context.SaveChangesAsync();

            return Ok(supplier);
        }

        private bool supplierMasterExists(int id)
        {
            return _context.supplierMasters.Any(e => e.supId == id);
        }
    }
}