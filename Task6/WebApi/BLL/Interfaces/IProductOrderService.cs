using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IProductOrderService
    {
        IEnumerable<ProductOrderDTO> GetProductOrders();
        ProductOrderDTO GetProductOrderById(int id);
        void CreateProductOrder(ProductOrderDTO orderDTO);
        void UpdateProductOrder(ProductOrderDTO orderDTO);
        void DeleteProductOrder(int id);
        void Dispose();
    }
}
