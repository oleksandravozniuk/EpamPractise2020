using AutoMapper;
using BLL.DTOs;
using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.Services;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

using WebApi.Models;

namespace WebApi.Controllers
{
    public class OrderModelsController : ApiController
    {
        public IOrderService orderService;
        private readonly IMapper mapper;

   

        public OrderModelsController()
        {
            orderService = new OrderService();
        }


        public OrderModelsController(IOrderService serv)
        {
            orderService = serv;

            MapperConfiguration configOrder = new MapperConfiguration(con =>
            {
                con.CreateMap<OrderModel, OrderDTO>();
                con.CreateMap<OrderDTO, OrderModel>();
            });
            mapper = configOrder.CreateMapper();


        }

        // GET: api/OrderModels
        public IQueryable<OrderModel> GetOrderModels()
        {
            IEnumerable<OrderDTO> orderDtos = orderService.GetOrders();
            var orders = mapper.Map<IEnumerable<OrderDTO>, List<OrderModel>>(orderDtos);
            return orders.AsQueryable();
        }

        // GET: api/OrderModels/5
        [ResponseType(typeof(OrderModel))]
        public IHttpActionResult GetOrderModel(int id)
        {
            OrderDTO orderDto = orderService.GetOrderById(id);

            if (orderDto == null)
            {
                return NotFound();
            }
            var orderModel = mapper.Map<OrderDTO, OrderModel>(orderDto);
            return Ok(orderModel);
        }

        // PUT: api/OrderModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrderModel(int id, OrderModel orderModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderModel.Id)
            {
                return BadRequest();
            }

            OrderDTO orderDTO = mapper.Map<OrderModel, OrderDTO>(orderModel);

            orderService.UpdateOrder(orderDTO);



            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/OrderModels
        [ResponseType(typeof(OrderModel))]
        public IHttpActionResult PostOrderModel(OrderModel orderModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            OrderDTO orderDTO = mapper.Map<OrderModel, OrderDTO>(orderModel);

            orderService.CreateOrder(orderDTO);


            return CreatedAtRoute("DefaultApi", new { id = orderModel.Id }, orderModel);
        }

        // DELETE: api/OrderModels/5
        [ResponseType(typeof(OrderModel))]
        public IHttpActionResult DeleteOrderModel(int id)
        {

            OrderDTO orderDTO = orderService.GetOrderById(id);

            OrderModel orderModel = mapper.Map<OrderDTO, OrderModel>(orderDTO);

            orderService.DeleteOrder(id);

            return Ok(orderModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                orderService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderModelExists(int id)
        {
            return orderService.GetOrders().Count(e => e.Id == id) > 0;
        }
    }
}