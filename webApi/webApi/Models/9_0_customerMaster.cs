using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.Models
{
    [Table("customerMaster")]
    public class customerMaster
    {
        [Key]
        [Column("custId")]
        public int custId { get; set; }
        public string custName { get; set; }
        public string custCity { get; set; }
        public string custArea { get; set; }
        public string custSociety { get; set; }

        [ForeignKey("flatNo")]
        public int flatNo { get; set; }
        public flatMaster flat { get; set; }

        public string custMobNo1 { get; set; }
        public string custMobNo2 { get; set; }
        public string custGeoLocation { get; set; }
        public bool isActive { get; set; }

    }
}
