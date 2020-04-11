using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using BLL.Services;
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
    public class ProductProductOrderModelsController : ApiController
    {
        public class ProductOrderModelsController : ApiController
        {
            public IProductOrderService productOrderService;
            private readonly IMapper mapper;
            private readonly IMapper orderMapper;
            private readonly IMapper productMapper;



            public ProductOrderModelsController()
            {
                productOrderService = new ProductOrderService();
            }


            public ProductOrderModelsController(IProductOrderService serv)
            {
                productOrderService = serv;


                MapperConfiguration configOrder = new MapperConfiguration(con =>
                {
                    con.CreateMap<OrderDTO, OrderModel>();
                    con.CreateMap<OrderModel, OrderDTO>();
                });
                orderMapper = configOrder.CreateMapper();

                MapperConfiguration configProduct = new MapperConfiguration(con =>
                {
                    con.CreateMap<ProductDTO, ProductModel>();
                    con.CreateMap<ProductModel, ProductDTO>();
                });
                productMapper = configProduct.CreateMapper();

                MapperConfiguration configProductOrder = new MapperConfiguration(con =>
                {
                    con.CreateMap<ProductOrderModel, ProductOrderDTO>()
                   .ForMember(dest => dest.Order, opt => opt.MapFrom(src => orderMapper.Map<OrderModel, OrderDTO>(src.Order)))
                   .ForMember(dest => dest.Product, opt => opt.MapFrom(src => productMapper.Map<ProductModel, ProductDTO>(src.Product)));

                    con.CreateMap<ProductOrderDTO, ProductOrderModel>()
                    .ForMember(dest => dest.Order, opt => opt.MapFrom(src => orderMapper.Map<OrderDTO, OrderModel>(src.Order)))
                    .ForMember(dest => dest.Product, opt => opt.MapFrom(src => productMapper.Map<ProductDTO, ProductModel>(src.Product)));
                });

                mapper = configProductOrder.CreateMapper();

               

            }

            // GET: api/ProductOrderModels
            public IQueryable<ProductOrderModel> GetProductOrderModels()
            {
                IEnumerable<ProductOrderDTO> productOrderDtos = productOrderService.GetProductOrders();
                var productOrders = mapper.Map<IEnumerable<ProductOrderDTO>, List<ProductOrderModel>>(productOrderDtos);
                return productOrders.AsQueryable();
            }

            // GET: api/ProductOrderModels/5
            [ResponseType(typeof(ProductOrderModel))]
            public IHttpActionResult GetProductOrderModel(int id)
            {
                ProductOrderDTO productOrderDto = productOrderService.GetProductOrderById(id);

                if (productOrderDto == null)
                {
                    return NotFound();
                }
                var productOrderModel = mapper.Map<ProductOrderDTO, ProductOrderModel>(productOrderDto);
                return Ok(productOrderModel);
            }

            // PUT: api/ProductOrderModels/5
            [ResponseType(typeof(void))]
            public IHttpActionResult PutProductOrderModel(int id, ProductOrderModel productOrderModel)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != productOrderModel.Id)
                {
                    return BadRequest();
                }

                ProductOrderDTO productOrderDTO = mapper.Map<ProductOrderModel, ProductOrderDTO>(productOrderModel);

                productOrderService.UpdateProductOrder(productOrderDTO);



                return StatusCode(HttpStatusCode.NoContent);
            }

            // POST: api/ProductOrderModels
            [ResponseType(typeof(ProductOrderModel))]
            public IHttpActionResult PostProductOrderModel(ProductOrderModel productOrderModel)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                ProductOrderDTO productOrderDTO = mapper.Map<ProductOrderModel, ProductOrderDTO>(productOrderModel);

                productOrderService.CreateProductOrder(productOrderDTO);


                return CreatedAtRoute("DefaultApi", new { id = productOrderModel.Id }, productOrderModel);
            }

            // DELETE: api/ProductOrderModels/5
            [ResponseType(typeof(ProductOrderModel))]
            public IHttpActionResult DeleteProductOrderModel(int id)
            {

                ProductOrderDTO productOrderDTO = productOrderService.GetProductOrderById(id);

                ProductOrderModel productOrderModel = mapper.Map<ProductOrderDTO, ProductOrderModel>(productOrderDTO);

                productOrderService.DeleteProductOrder(id);

                return Ok(productOrderModel);
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    productOrderService.Dispose();
                }
                base.Dispose(disposing);
            }

            private bool ProductOrderModelExists(int id)
            {
                return productOrderService.GetProductOrders().Count(e => e.Id == id) > 0;
            }
        }
    }
}