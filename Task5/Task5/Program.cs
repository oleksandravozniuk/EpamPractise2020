using BLL.DTOs;
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

            //// внедрение зависимостей
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Epam_Task5;Integrated Security=True";
            NinjectModule storeModule = new StoreModule();
            NinjectModule serviceModule = new ServiceModule(connectionString);
            var kernel = new StandardKernel(storeModule, serviceModule);

            var productService = kernel.Get<IProductService>();
            var categoryService = kernel.Get<ICategoryService>();
            var supplierService = kernel.Get<ISupplierService>();

            Console.WriteLine("Print all categories:");
            PrintAllCategories(categoryService);
            Console.WriteLine("Print all suppliers");
            PrintAllSuppliers(supplierService);
            Console.WriteLine("Print all products");
            PrintAllProducts(productService);

            Console.WriteLine();
            Console.WriteLine("Print the product with the name Product 1");
            PrintProductByName(productService, "Product 1");

            Console.WriteLine();
            Console.WriteLine("Print products with fixed price = 100");
            PrintProductsByFixedPrice(productService, 100);

            Console.WriteLine();
            Console.WriteLine("Print product with the name Supplier 1");
            PrintProductsBySupplier(productService, "Supplier 1");

            Console.WriteLine();
            Console.WriteLine("Print product with the name Category 1");
            PrintProductsByCategory(productService, "Category 1");

            Console.WriteLine();
            Console.WriteLine("Print category with the name Category 2");
            PrintCategoryByName(categoryService, "Category 2");

            Console.WriteLine();
            Console.WriteLine("Print supplier with the name Supplier 2");
            PrintSupplierByName(supplierService, "Supplier 2");

            Console.WriteLine();
            Console.WriteLine("Print suppliers with the name of category 'Category 3'");
            PrintSupplierByCategory(supplierService, "Category 3");

            Console.WriteLine();
            Console.WriteLine("Print suppliers with mx category");
            PrintSuppliersByMaxCategory(supplierService);
            
            Console.ReadKey();
        }

        static void PrintAllProducts(IProductService productService)
        {

            var products = productService.GetProducts();

            foreach (var product in products)
                Console.WriteLine("ProductId: {0}, ProductName: {1}, Category: {2}, Supplier: {3}, ProductPrice: {4}", product.ProductId, product.ProductName, product.Category.CategoryName, product.Supplier.SupplierName, product.Price);
            
        }

        static void PrintAllCategories(ICategoryService categoryService)
        {

            var categories = categoryService.GetCategories();

            foreach (var category in categories)
                Console.WriteLine("CategoryId: {0}, categoryName: {1}", category.CategoryId, category.CategoryName);

        }

        static void PrintAllSuppliers(ISupplierService supplierService)
        {

            var suppliers = supplierService.GetSuppliers();

            foreach (var supplier in suppliers)
                Console.WriteLine("SupplierId: {0}, SupplierName: {1}", supplier.SupplierId, supplier.SupplierName);

        }
        static void PrintProductByName(IProductService productService, string productName)
        {
            var product = productService.GetProductByName(productName);

                Console.WriteLine("ProductId: {0}, ProductName: {1}, Category: {2}, Supplier: {3}, ProductPrice: {4}", product.ProductId, product.ProductName, product.Category.CategoryName, product.Supplier.SupplierName, product.Price);
        }
        static void PrintProductsByFixedPrice(IProductService productService,int price)
        {
            var productsWithFixedPrice = productService.GetProductsByFixedPrice(price);

            foreach(var product in productsWithFixedPrice)
                Console.WriteLine("ProductId: {0}, ProductName: {1}, Category: {2}, Supplier: {3}, ProductPrice: {4}", product.ProductId, product.ProductName, product.Category.CategoryName, product.Supplier.SupplierName, product.Price);
        }

        static void PrintProductsBySupplier(IProductService productService, string supplier)
        {
            var productsBySupplier = productService.GetProductsBySupplier(supplier);

            foreach (var product in productsBySupplier)
                Console.WriteLine("ProductId: {0}, ProductName: {1}, Category: {2}, Supplier: {3}, ProductPrice: {4}", product.ProductId, product.ProductName, product.Category.CategoryName, product.Supplier.SupplierName, product.Price);
        }

        static void PrintProductsByCategory(IProductService productService, string category)
        {
            var productsByCategory = productService.GetProductsByCategory(category);

            foreach (var product in productsByCategory)
                Console.WriteLine("ProductId: {0}, ProductName: {1}, Category: {2}, Supplier: {3}, ProductPrice: {4}", product.ProductId, product.ProductName, product.Category.CategoryName, product.Supplier.SupplierName, product.Price);
        }

        static void PrintCategoryByName(ICategoryService categoryService, string categoryName)
        {
            var category = categoryService.GetCategoryByName(categoryName);
            Console.WriteLine("CategoryId: {0}, categoryName: {1}", category.CategoryId, category.CategoryName);

        }

        static void PrintSupplierByName(ISupplierService supplierService, string supplierName)
        {
            var supplier = supplierService.GetSupplierByName(supplierName);
            Console.WriteLine("SupplierId: {0}, supplierName: {1}", supplier.SupplierId, supplier.SupplierName);

        }

        static void PrintSupplierByCategory(ISupplierService supplierService, string categoryName)
        {
            var suppliers = supplierService.GetSuppliersByCategory(categoryName);
            foreach(var supplier in suppliers)
                Console.WriteLine("SupplierId: {0}, supplierName: {1}", supplier.SupplierId, supplier.SupplierName);
        }

        static void PrintSuppliersByMaxCategory(ISupplierService supplierService)
        {
            var suppliers = supplierService.GetSuppliersByMaxCategory();
            foreach (var supplier in suppliers)
                Console.WriteLine("SupplierId: {0}, supplierName: {1}", supplier.SupplierId, supplier.SupplierName);
        }
    }
}
