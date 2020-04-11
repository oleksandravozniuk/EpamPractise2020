using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetProducts();
        ProductDTO GetProductById(int id);
        void CreateProduct(ProductDTO productDTO);
        void UpdateProduct(ProductDTO productDTO);
        void DeleteProduct(int id);
        void Dispose();
    }
}
