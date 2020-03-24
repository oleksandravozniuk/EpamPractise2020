using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using System.Configuration;
using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.DTOs;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Epam_Task5;Integrated Security=True";
            StandardKernel ninject = new StandardKernel(new ServiceModule(connectionString));

         

            //IProductService product = ninject.Get<IProductService>();
            ICategoryService category = ninject.Get<ICategoryService>();
            //ISupplierService supplier = ninject.Get<ISupplierService>();

            CategoryDTO cat1 = new CategoryDTO();
            cat1.CategoryId = 1;
            cat1.CategoryName = "c1";

            category.Create(cat1);

        }


    }
}
