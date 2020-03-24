using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

using DAL_EF.Entities;
using DAL_EF.Interfaces;

//using DAL_ADONET.Entities;
//using DAL_ADONET.Interfaces;

namespace BLL.Services
{
    public class ProductService:IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork != null)
                this.unitOfWork = unitOfWork;

            MapperConfiguration config = new MapperConfiguration(con =>
            {
                con.CreateMap<Product, ProductDTO>();
                con.CreateMap<ProductDTO, Product>();
            });

            mapper = config.CreateMapper();
        }

        public void Create(ProductDTO product)
        {
            if (product == null)
                throw new ValidationException("Cannot create the nullable instance of Product");

            try
            {
                Product newProduct = mapper.Map<Product>(product);
                unitOfWork.Products.Add(newProduct);
                unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new ValidationException("Cannot create an instance of Product", ex);
            }
        }

        public void Update(ProductDTO product)
        {
            try
            {
                Product newProduct = mapper.Map<Product>(product);
                unitOfWork.Products.Update(newProduct);
                unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new ValidationException("Cannot update an instance of Product", ex);
            }
        }

        public void Delete(int product)
        {
            try
            {
                unitOfWork.Products.Delete(product);
                unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new ValidationException("Cannot delete an instance of Product", ex);
            }
        }

        public ProductDTO GetById(int id)
        {
            ProductDTO productDTO;
            try
            {
                productDTO = mapper.Map<ProductDTO>(unitOfWork.Products.GetById(id));
            }
            catch (Exception ex)
            {
                throw new ValidationException("Cannot get an instance of Product", ex);
            }

            return productDTO;
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            IEnumerable<ProductDTO> productDTOs;
            try
            {
                productDTOs = mapper.Map<IEnumerable<ProductDTO>>(unitOfWork.Products.GetAll());
            }
            catch (Exception ex)
            {
                throw new ValidationException("Cannot get an instances of Product", ex);
            }

            return productDTOs;
        }

        public IEnumerable<ProductDTO> GetProductsFromCategory(string category)
        {
            try
            {
                var result = mapper.Map<IEnumerable<ProductDTO>>(
                 unitOfWork.Products.GetAll().Where(x => x.Category.CategoryName == category).ToList());
                return result;
            }
            catch (Exception ex)
            {
                throw new ValidationException("Cannot get all an instances of Product", ex);
            }
        }

        public IEnumerable<ProductDTO> GetProductsFromSupplier(string supplier)
        {
            try
            {
                var result = mapper.Map<IEnumerable<ProductDTO>>(
                unitOfWork.Products.GetAll().Where(x => x.Supplier.SupplierName == supplier).ToList());
                return result;
            }
            catch (Exception ex)
            {
                throw new ValidationException("Cannot get all an instances of Product", ex);
            }
        }

      

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
