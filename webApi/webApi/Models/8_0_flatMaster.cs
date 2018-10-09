using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.Models
{
    [Table("flatMaster")]
    public class flatMaster
    {
        [Key]
        public int flatNo { get; set; }
        public string flatName { get; set; }

        [ForeignKey("societyId")]
        public int societyId { get; set; }
        public societyMaster societyMaster { get; set; }
    }
}
