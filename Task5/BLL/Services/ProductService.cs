using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL_EF.Entities;
using DAL_EF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService:IProductService
    {
        IUnitOfWork Database { get; set; }

        public ProductService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(Database.Products.GetAll().ToList());
        }

        public void CreateProduct(ProductDTO productDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            Product newProduct = mapper.Map<Product>(productDTO);
            Database.Products.Create(newProduct);
            Database.Save();
        }
        public void UpdateProduct(ProductDTO productDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            Product newProduct = mapper.Map<Product>(productDTO);
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
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            return mapper.Map<Product, ProductDTO>(Database.Products.Get(p => p.ProductId == productId).First());
        }

        public ProductDTO GetProductByName(string productName)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            return mapper.Map<Product, ProductDTO>(Database.Products.Get(p => p.ProductName == productName).First());
        }

        public IEnumerable<ProductDTO> GetProductsByCategory(int categoryId)
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(Database.Products.Get(p => p.Category.CategoryId == categoryId));
        }

        public IEnumerable<ProductDTO> GetProductsBySupplier(int supplierId)
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(Database.Products.Get(p => p.Supplier.SupplierId == supplierId));
        }


        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
