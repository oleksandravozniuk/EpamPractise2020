using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{

        public class StoreContext : DbContext
        {
            public DbSet<Product> Products { get; set; }
            public DbSet<Order> Orders { get; set; }

            public DbSet<ProductOrder> ProductOrders { get; set; }

            //public StoreContext() : base("DefaultConnection")
            //{
            //    Database.SetInitializer(new MigrateDatabaseToLatestVersion<StoreContext, Migrations.Configuration>());
            //}
            //public StoreContext(string connectionString)
            //         : base(connectionString)
            //{
            //    Database.SetInitializer(new MigrateDatabaseToLatestVersion<StoreContext, Migrations.Configuration>());
            //}

            static StoreContext()
            {
                Database.SetInitializer<StoreContext>(new StoreDbInitializer());
            }
            public StoreContext(string connectionString)
                : base(connectionString)
            {
            }
        }



    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {

            Product p1 = new Product { Id = 1, Name = "Product 1", Price = 100 };
            Product p2 = new Product { Id = 2, Name = "Product 2", Price = 190 };
            Product p3 = new Product { Id = 3, Name = "Product 3", Price = 88 };
            Product p4 = new Product { Id = 4, Name = "Product 4", Price = 29 };
            Product p5 = new Product { Id = 5, Name = "Product 5", Price = 56 };
            Product p6 = new Product { Id = 6, Name = "Product 6", Price = 123 };

            Order o1 = new Order { Id = 1 };
            Order o2 = new Order { Id = 2 };

            ProductOrder po1 = new ProductOrder { OrderId = 1, ProductId = 1 };
            ProductOrder po2 = new ProductOrder { OrderId = 2, ProductId = 1 };




            context.Products.Add(p1);
            context.Products.Add(p2);
            context.Products.Add(p3);
            context.Products.Add(p4);
            context.Products.Add(p5);
            context.Products.Add(p6);

            context.Orders.Add(o1);
            context.Orders.Add(o2);

            context.ProductOrders.Add(po1);
            context.ProductOrders.Add(po2);




            context.SaveChanges();


        }
    }

}
