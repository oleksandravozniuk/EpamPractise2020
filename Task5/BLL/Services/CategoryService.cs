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
        private readonly IMapper mapper;

        public CategoryService(IUnitOfWork uow)
        {
            if (uow != null)
                this.Database = uow;

            MapperConfiguration config = new MapperConfiguration(con =>
            {
                con.CreateMap<Category, CategoryDTO>();
                con.CreateMap<CategoryDTO, Category>();
            });

            mapper = config.CreateMapper();
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            return mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(Database.Categories.GetAll().ToList());
        }

        public CategoryDTO GetCategoryById(int id)
        {
            return mapper.Map<Category, CategoryDTO>(Database.Categories.Get(p => p.CategoryId == id).First());
        }

        public void CreateCategory(CategoryDTO categoryDTO)
        {
            Category newCategory = mapper.Map<Category>(categoryDTO);
            Database.Categories.Create(newCategory);
            Database.Save();
        }
        public void UpdateCategory(CategoryDTO categoryDTO)
        {
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
            return mapper.Map<Category, CategoryDTO>(Database.Categories.Get(p => p.CategoryName == categoryName).First());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
