using AutoMapper;
using BLL.DTOs;
using BLL.Infrastructure;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

using DAL_EF.Entities;
using DAL_EF.Interfaces;

//using DAL_ADONET.Entities;
//using DAL_ADONET.Interfaces;

namespace BLL.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork != null)
                this.unitOfWork = unitOfWork;

            MapperConfiguration config = new MapperConfiguration(con =>
            {
                con.CreateMap<CategoryDTO, Product>();
                con.CreateMap<Category, CategoryDTO>();

                con.CreateMap<ProductDTO, Product>();
                con.CreateMap<Product, ProductDTO>();
            }
            );

            mapper = config.CreateMapper();
        }

        public void Create(CategoryDTO categoryProduct)
        {
            if (categoryProduct == null)
                throw new ValidationException("Cannot create the nullable instance of CategoryProduct");

            try
            {
                Category newCategory = mapper.Map<Category>(categoryProduct);
                unitOfWork.Categories.Add(newCategory);
                unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new ValidationException("Cannot create an instance of CategoryProduct", ex);
            }
        }

        public void Update(CategoryDTO categoryProduct)
        {
            try
            {
                Category newCategory = mapper.Map<Category>(categoryProduct);
                unitOfWork.Categories.Update(newCategory);
                unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new ValidationException("Cannot update an instance of CategoryProduct", ex);
            }
        }

        public void Delete(int categoryProductId)
        {
            try
            {
                unitOfWork.Categories.Delete(categoryProductId);
                unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new ValidationException("Cannot delete an instance of CategoryProduct", ex);
            }
        }

        public CategoryDTO GetById(int id)
        {
            CategoryDTO categoryProductDTO;
            try
            {
                categoryProductDTO = mapper.Map<CategoryDTO>(unitOfWork.Categories.GetById(id));
            }
            catch (Exception ex)
            {
                throw new ValidationException("Cannot get an instance of CategoryProduct", ex);
            }

            return categoryProductDTO;
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            IEnumerable<CategoryDTO> categoryProductDTOs;
            try
            {
                categoryProductDTOs = mapper.Map<IEnumerable<CategoryDTO>>(unitOfWork.Categories.GetAll());
            }
            catch (Exception ex)
            {
                throw new ValidationException("Cannot get an instances of CategoryProduct", ex);
            }

            return categoryProductDTOs;
        }


        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
