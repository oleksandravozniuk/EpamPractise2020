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
    public class ProductService : IProductService
    {
        IUnitOfWork Database { get; set; }
        private readonly IMapper productMapper;
        private readonly IMapper productOrderMapper;



        public ProductService(IUnitOfWork uow)
        {
            if (uow != null)
                this.Database = uow;


      
            MapperConfiguration configProduct = new MapperConfiguration(con =>
            {
               
                con.CreateMap<Product, ProductDTO>();
                con.CreateMap<ProductDTO, Product>();
            });

            productMapper = configProduct.CreateMapper();


        }

        public ProductService()
        {
        }

        public IEnumerable<ProductDTO> GetProducts()
        {

           
            var products = productMapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(Database.Products.GetAll());
            return products;
           
        }

        public void CreateProduct(ProductDTO productDTO)
        {

            Product newProduct = productMapper.Map<Product>(productDTO);
            Database.Products.Create(newProduct);
            Database.Save();
        }
        public void UpdateProduct(ProductDTO productDTO)
        {
            Product newProduct = productMapper.Map<Product>(productDTO);
            Database.Products.Update(newProduct);
            Database.Save();
        }

        public void DeleteProduct(int id)
        {
            Database.Products.Delete(id);
            Database.Save();
        }

        public ProductDTO GetProductById(int productId)
        {
            return productMapper.Map<Product, ProductDTO>(Database.Products.Get(p => p.Id == productId).First());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
