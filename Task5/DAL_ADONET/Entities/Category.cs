using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL_ADONET.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(20)]
        public string CategoryName { get; set; }
    }
}
