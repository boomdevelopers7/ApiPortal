using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.Models
{
    [Table("supplierMaster")]
    public class supplierMaster
    {
        [Key]
        public int supId { get; set; }
        public string supName { get; set; }
        public string supAddress { get; set; }
        public string supMobNo { get; set; }
        public string supMobNo2 { get; set; }
        public string supPincode { get; set; }
    }
}
