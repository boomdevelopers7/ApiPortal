using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.Models
{
    [Table("adminLogin")]
    public class AdminLogin
    {
        [Column("adminId")]
        public int ID { get; set; }

        [Column("adminUserName")]
        public String UserName { get; set; }

        [Column("adminPassword")]
        public String Password { get; set; }
    }
}
