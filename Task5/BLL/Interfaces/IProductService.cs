using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    interface IProductService
    {
        void Create(ProductDTO product);
        void Update(ProductDTO product);
        void Delete(int productId);

        ProductDTO GetById(int id);

        IEnumerable<ProductDTO> GetAll();
        IEnumerable<ProductDTO> GetProductsFromCategory(string category);
        IEnumerable<ProductDTO> GetProductsFromSupplier(string supplier);
    }
}
