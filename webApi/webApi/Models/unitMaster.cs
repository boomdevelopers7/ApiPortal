using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.Models
{
    [Table("unitMaster")]
    public class unitMaster
    {
        [Column("unitId")]
        public int ID { get; set; }
        public string unitName { get; set; }
        public string unitDescription { get; set; }
    }
}
