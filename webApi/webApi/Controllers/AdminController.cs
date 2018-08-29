using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webApi.Models;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        private readonly AdminDbContext _context;

        public AdminController(AdminDbContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public List<AdminLogin> Get()
        {
            var admn = _context.AdminLogins.ToList();
            return (admn);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var admn = _context.AdminLogins.Find(id);
            if (admn == null)
            {
                return NotFound();
            }
            return Ok(admn);
        }

        // POST api/values
        [HttpPost]
        public IActionResult AdminLogin([FromBody]AdminLogin obj)
        {

            var list1 = _context.AdminLogins.ToList();
            var list = _context.AdminLogins.ToList().Where(s => s.UserName == obj.UserName & s.Password == obj.Password);
            if (list.Count() > 0)
                return Ok("Login Successful");
                
            return NotFound("Invalid Login details");

        }



        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
