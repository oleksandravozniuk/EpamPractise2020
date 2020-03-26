using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ADONET.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(20)]
        public string ProductName { get; set; }

        public int Price { get; set; }

        public int? SupplierId { get; set; }

        public int? CategoryId { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual Category Category { get; set; }

    }
}
