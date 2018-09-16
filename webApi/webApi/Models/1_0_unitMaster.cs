using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.Models
{
    [Table("unitMaster")]
    public class unitMaster
    {[Key]
        [Column("unitId")]
        public int unitId { get; set; }
        public string unitName { get; set; }
        public string unitDescription { get; set; }
        //public ICollection<ItemMaster> itemMasters { get; set; }
    }
}
