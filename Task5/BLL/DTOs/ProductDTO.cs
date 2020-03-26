using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int Price { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }

        public virtual SupplierDTO Supplier { get; set; }
        public virtual CategoryDTO Category { get; set; }

    }
}
