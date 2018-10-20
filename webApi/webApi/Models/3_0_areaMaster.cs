using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.Models
{   
    [Table("areaMaster")]
    public class areaMaster
    { 
        [Key]
        public int areaId { get; set; }
        public string areaName { get; set; }
        [ForeignKey("cityId")]
        public int cityId { get; set; }
        public cityMaster cityMaster { get; set; }
        public bool isActive { get; set; }

    }
}
