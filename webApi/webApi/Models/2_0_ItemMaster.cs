using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.Models
{
    [Table("itemMaster")]
    public class ItemMaster
    {
        [Key]
        [Column("itemId")]
        public int itemId { get; set; }
        public string itemName { get; set; }
        public int itemQuantity { get; set; }
        public double itemPrice { get; set; }
        [ForeignKey("unitId")]
        public int unitId { get; set; }
        public unitMaster unitMaster { get; set; }
        [ForeignKey("typeId")]
        public int typeId { get; set; }
        public  typeMaster typeMaster   { get; set; }
    }


}
