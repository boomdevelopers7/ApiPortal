using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.Models;

namespace webApi.Data
{
    public class MyDbContext : DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        { }
        public DbSet<AdminLogin> AdminLogins { get; set; }
        public DbSet<ItemMaster> ItemMasters { get; set; }
        public DbSet<unitMaster> unitMasters { get; set; }
        public DbSet<typeMaster> typeMasters { get; set; }
        public DbSet<areaMaster> areaMasters { get; set; }
        public DbSet<societyMaster> societyMasters { get; set; }
<<<<<<< HEAD
        public DbSet<cityMaster> cityMaster { get; set; }
=======
>>>>>>> f83e8abafc5fee7f48d1582ac6286c93e52bc9ba

    }
}
