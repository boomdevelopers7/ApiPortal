using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.Models
{
    public class AdminDbContext : DbContext
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options)
        { }
        public DbSet<AdminLogin> AdminLogins { get; set; }
    }
}
