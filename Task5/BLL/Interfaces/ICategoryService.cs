using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    interface ICategoryService
    {
        void Create(CategoryDTO categoryProduct);
        void Update(CategoryDTO categoryProduct);
        void Delete(int categoryId);

        CategoryDTO GetById(int id);

        IEnumerable<CategoryDTO> GetAll();
    }
}
