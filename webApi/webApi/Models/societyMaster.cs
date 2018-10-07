﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.Models
{
    [Table("societyMaster")]
    public class societyMaster
    {
        [Key]
        public int societyId { get; set; }
        public string societyName { get; set; }
    }
}
