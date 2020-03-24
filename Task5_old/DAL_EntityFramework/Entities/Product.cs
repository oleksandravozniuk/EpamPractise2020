using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL_EF.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(20)]
        public string ProductName { get; set; }

        [Required]
        [MaxLength(20)]
        public Supplier Supplier { get; set; }

        [Required]
        [MaxLength(20)]
        public Category Category { get; set; }
    }
}
