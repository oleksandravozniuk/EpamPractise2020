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
    public class ProductOrderService : IProductOrderService
    {
        IUnitOfWork Database { get; set; }
        private readonly IMapper productOrderMapper;
        private readonly IMapper productMapper;
        private readonly IMapper orderMapper;


        public ProductOrderService(IUnitOfWork uow)
        {
            if (uow != null)
                this.Database = uow;


            MapperConfiguration configOrder = new MapperConfiguration(con =>
            {
                con.CreateMap<Order, OrderDTO>();
                con.CreateMap<OrderDTO, Order>();
            });
            orderMapper = configOrder.CreateMapper();

            MapperConfiguration configProduct = new MapperConfiguration(con =>
            {
                con.CreateMap<Product, ProductDTO>();
                con.CreateMap<ProductDTO, Product>();
            });
            productMapper = configProduct.CreateMapper();

            MapperConfiguration configProductOrder = new MapperConfiguration(con =>
            {
                con.CreateMap<ProductOrderDTO, ProductOrder>()
               .ForMember(dest => dest.Order, opt => opt.MapFrom(src => orderMapper.Map<OrderDTO, Order>(src.Order)))
               .ForMember(dest => dest.Product, opt => opt.MapFrom(src => productMapper.Map<ProductDTO, Product>(src.Product)));

                con.CreateMap<ProductOrder, ProductOrderDTO>()
                .ForMember(dest => dest.Order, opt => opt.MapFrom(src => orderMapper.Map<Order, OrderDTO>(src.Order)))
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => productMapper.Map<Product, ProductDTO>(src.Product)));
            });

            productOrderMapper = configProductOrder.CreateMapper();



        }

        public ProductOrderService()
        {
        }

        public IEnumerable<ProductOrderDTO> GetProductOrders()
        {

            return productOrderMapper.Map<IEnumerable<ProductOrder>, List<ProductOrderDTO>>(Database.ProductOrders.GetAll());
        }

        public void CreateProductOrder(ProductOrderDTO productOrderDTO)
        {

            ProductOrder newProductOrder = productOrderMapper.Map<ProductOrder>(productOrderDTO);
            Database.ProductOrders.Create(newProductOrder);
            Database.Save();
        }
        public void UpdateProductOrder(ProductOrderDTO productOrderDTO)
        {
            ProductOrder newProductOrder = productOrderMapper.Map<ProductOrder>(productOrderDTO);
            Database.ProductOrders.Detach(newProductOrder);
            Database.ProductOrders.Update(newProductOrder);
            Database.Save();
        }

        public void DeleteProductOrder(int id)
        {
            Database.ProductOrders.Delete(id);
            Database.Save();
        }

        public ProductOrderDTO GetProductOrderById(int productOrderId)
        {
            return productOrderMapper.Map<ProductOrder, ProductOrderDTO>(Database.ProductOrders.Get(p => p.Id == productOrderId).First());
        }


        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
