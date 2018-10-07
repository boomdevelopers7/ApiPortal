using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.Models
{
    [Table("typeMaster")]
    public class typeMaster
    {
        [Key]
        [Column("typeId")]
        public int typeId { get; set; }
        public string typeName { get; set; }
        public string typeDescription { get; set; }
        public Boolean isActive { get; set; }
    }
}
