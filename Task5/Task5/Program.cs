using BLL.Infrastructure;
using BLL.Interfaces;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            //StoreModule storeModule = new StoreModule();
            //storeModule.Load();
            //StandardKernel ninject = new StandardKernel(new ServiceModule("DbConnection"));

            //IProductService product = ninject.Get<IProductService>();
            //ICategoryService category = ninject.Get<ICategoryService>();
            //ISupplierService supplier = ninject.Get<ISupplierService>();

            //// внедрение зависимостей
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Epam_Task5;Integrated Security=True";
            NinjectModule storeModule = new StoreModule();
            NinjectModule serviceModule = new ServiceModule(connectionString);
            var kernel = new StandardKernel(storeModule, serviceModule);

            //IProductService productService = kernel.Get<IProductService>();


            

            var productService = kernel.Get<IProductService>();
            var categorySevice = kernel.Get<ICategoryService>();

            categorySevice.CreateCategory(new BLL.DTOs.CategoryDTO {CategoryName = "C8484" });

            PrintAllCategories(categorySevice);

            PrintAllProducts(productService);

            Console.ReadKey();
        }

        static void PrintAllProducts(IProductService productService)
        {
            
            var products = productService.GetProducts();

            foreach (var product in products)
                Console.WriteLine("ProductId: {0}, ProductName: {1}, Category: {2}, Supplier: {3}", product.ProductId, product.ProductName,product, product.CategoryId, product.SupplierId);
            
        }

        static void PrintAllCategories(ICategoryService categoryService)
        {

            var categories = categoryService.GetCategories();

            foreach (var category in categories)
                Console.WriteLine("CategoryId: {0}, categoryName: {1}", category.CategoryId, category.CategoryName);

        }
    }
}
