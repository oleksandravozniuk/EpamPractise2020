using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderDTO> GetOrders();
        OrderDTO GetOrderById(int id);
        void CreateOrder(OrderDTO orderDTO);
        void UpdateOrder(OrderDTO orderDTO);
        void DeleteOrder(int id);
        void Dispose();
    }
}
