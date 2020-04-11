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

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //// внедрение зависимостей
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Epam6;Integrated Security=True";
            NinjectModule storeModule = new StoreModule();
            NinjectModule serviceModule = new ServiceModule(connectionString);
            var kernel = new StandardKernel(storeModule, serviceModule);

            var productService = kernel.Get<IProductService>();
            var orderService = kernel.Get<IOrderService>();
            var productOrderService = kernel.Get<IProductOrderService>();

            System.Console.WriteLine("Print all products:");

          

            //var p1 = productService.GetProductById(1);
            //var p2 = productService.GetProductById(2);


            ////OrderDTO orderDTO = new OrderDTO { Name = 100 };
            ////orderService.CreateOrder(orderDTO);

            //var order = orderService.GetOrderById(4);

            //order.Products.Add(p1);
            ////p1.Orders.Add(order);
            //order.Products.Add(p2);
            ////p2.Orders.Add(order);
            //orderService.UpdateProductsList(order);
            ////productService.UpdateOrdersList(p1);
            ////productService.UpdateOrdersList(p2);

            //var order2 = orderService.GetOrderById(5);

            //order2.Products.Add(p1);
            //orderService.UpdateProductsList(order2);


            var products = productService.GetProducts();
            foreach (var p in products)
            {
                System.Console.WriteLine(p.Name);
               
            }

            var orders = orderService.GetOrders();
            foreach (var o in orders)
            {
                System.Console.WriteLine(o.Id);
              
            }

            var pairs = productOrderService.GetProductOrders();
            foreach (var o in pairs)
            {
                System.Console.WriteLine(o.OrderId + " - " + o.ProductId);

            }

            System.Console.ReadKey();
        }
    }
}
