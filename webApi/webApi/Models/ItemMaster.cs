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
        public int ID { get; set; }
        [Column("itemName")]
        public string Name { get; set; }
        [Column("itemQuantity")]
        public int Quantity { get; set; }
        [Column("itemUnit")]
        public string Unit { get; set; }
        [Column("itemPrise")]
        public int Prise { get; set; }

    }
}
