using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL_ADONET.Entities
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        [Required]
        [MaxLength(20)]
        public string SupplierName { get; set; }
    }
}
