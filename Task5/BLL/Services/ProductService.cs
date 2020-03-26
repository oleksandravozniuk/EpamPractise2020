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
        private readonly IMapper productMapper;
        private readonly IMapper categoryMapper;
        private readonly IMapper supplierMapper;


        public ProductService(IUnitOfWork uow)
        {
                if (uow != null)
                    this.Database = uow;

            MapperConfiguration configCategory = new MapperConfiguration(con => 
            {
                con.CreateMap<Category, CategoryDTO>();
                con.CreateMap<CategoryDTO, Category>();
            });
            categoryMapper = configCategory.CreateMapper();

            MapperConfiguration configSupplier = new MapperConfiguration(con =>
            {
                con.CreateMap<Supplier, SupplierDTO>();
                con.CreateMap<SupplierDTO, Supplier>();
            });
            supplierMapper = configSupplier.CreateMapper();

            MapperConfiguration configProduct = new MapperConfiguration(con =>
            {
                con.CreateMap<ProductDTO, Product>()
               .ForMember(dest => dest.Category, opt => opt.MapFrom(src => categoryMapper.Map<CategoryDTO, Category>(src.Category)))
               .ForMember(dest => dest.Supplier, opt => opt.MapFrom(src => supplierMapper.Map<SupplierDTO, Supplier>(src.Supplier)));

                con.CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => categoryMapper.Map<Category, CategoryDTO>(src.Category)))
                .ForMember(dest => dest.Supplier, opt => opt.MapFrom(src => supplierMapper.Map<Supplier, SupplierDTO>(src.Supplier)));
            });

            productMapper = configProduct.CreateMapper();


        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            return productMapper.Map<IEnumerable<Product>, List<ProductDTO>>(Database.Products.GetAll());  
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
            return productMapper.Map<Product, ProductDTO>(Database.Products.Get(p => p.ProductId == productId).First());
        }

        public ProductDTO GetProductByName(string productName)
        {
            return productMapper.Map<Product, ProductDTO>(Database.Products.Get(p => p.ProductName == productName).First());
        }

        public IEnumerable<ProductDTO> GetProductsByCategory(string category)
        {
            // применяем автомаппер для проекции одной коллекции на другую
           
            return productMapper.Map<IEnumerable<Product>, List<ProductDTO>>(Database.Products.Get(p => p.Category.CategoryName == category).ToList());
        }

        public IEnumerable<ProductDTO> GetProductsBySupplier(string supplier)
        {
            // применяем автомаппер для проекции одной коллекции на другую

            return productMapper.Map<IEnumerable<Product>, List<ProductDTO>>(Database.Products.Get(p => p.Supplier.SupplierName == supplier).ToList());
        }

        public IEnumerable<ProductDTO> GetProductsByFixedPrice(int price)
        {

            var products = productMapper.Map<IEnumerable<ProductDTO>>(Database.Products.Get(x => x.Price == price).ToList());
            return products;
        }



        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
