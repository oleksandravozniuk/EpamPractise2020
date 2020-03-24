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
    public class CategoryService:ICategoryService
    {
        IUnitOfWork Database { get; set; }

        public CategoryService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(Database.Categories.GetAll().ToList());
        }

        public CategoryDTO GetCategoryById(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            return mapper.Map<Category, CategoryDTO>(Database.Categories.Get(p => p.CategoryId == id).First());
        }

        public void CreateCategory(CategoryDTO categoryDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryDTO, Category>()).CreateMapper();
            Category newCategory = mapper.Map<Category>(categoryDTO);
            Database.Categories.Create(newCategory);
            Database.Save();
        }
        public void UpdateCategory(CategoryDTO categoryDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            Category newCategory = mapper.Map<Category>(categoryDTO);
            Database.Categories.Update(newCategory);
            Database.Save();
        }

        public void DeleteCategory(int id)
        {
            Database.Categories.Delete(id);
            Database.Save();
        }

        public CategoryDTO GetCategoryByName(string categoryName)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            return mapper.Map<Category, CategoryDTO>(Database.Categories.Get(p => p.CategoryName == categoryName).First());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
