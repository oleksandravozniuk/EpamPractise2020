using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public SupplierDTO Supplier { get; set; }

        public CategoryDTO Category { get; set; }
    }
}
