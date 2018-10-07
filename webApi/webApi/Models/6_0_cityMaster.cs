using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.Models
{
    [Table("cityMaster")]
    public class cityMaster
    {
        [Key]
        [Column("cityId")]
        public long cityId { get; set; }
        public string cityName { get; set; }
        public bool? isActive { get; set; }
    }
}