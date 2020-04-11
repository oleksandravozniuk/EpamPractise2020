using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        IUnitOfWork Database { get; set; }
        private readonly IMapper orderMapper;


        public OrderService(IUnitOfWork uow)
        {
            if (uow != null)
                this.Database = uow;


            MapperConfiguration configOrder = new MapperConfiguration(con =>
            {
      
                con.CreateMap<Order, OrderDTO>();
                con.CreateMap<OrderDTO, Order>();
            });
            orderMapper = configOrder.CreateMapper();



        }

        public OrderService()
        {
        }

        public IEnumerable<OrderDTO> GetOrders()
        {
            
            return orderMapper.Map<IEnumerable<Order>, List<OrderDTO>>(Database.Orders.GetAll());
        }

        public void CreateOrder(OrderDTO orderDTO)
        {

            Order newOrder = orderMapper.Map<Order>(orderDTO);
            Database.Orders.Create(newOrder);
            Database.Save();
        }
        public void UpdateOrder(OrderDTO orderDTO)
        {
            Order newOrder = orderMapper.Map<Order>(orderDTO);
            Database.Orders.Detach(newOrder);
            Database.Orders.Update(newOrder);
            Database.Save();
        }

        public void DeleteOrder(int id)
        {
            Database.Orders.Delete(id);
            Database.Save();
        }

        public OrderDTO GetOrderById(int orderId)
        {
            return orderMapper.Map<Order, OrderDTO>(Database.Orders.Get(p => p.Id == orderId).First());
        }


        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
