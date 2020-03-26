using DAL_EF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_EF.Context
{
    public class StoreContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        static StoreContext()
        {
            Database.SetInitializer<StoreContext>(new StoreDbInitializer());
        }
        public StoreContext(string connectionString)
            : base(connectionString)
        {
        }

    }



    public class StoreDbInitializer : DropCreateDatabaseAlways<StoreContext>
    {
        protected override void Seed(StoreContext db)
        {
            Category c1 = new Category {CategoryId=1, CategoryName = "Category 1" };
            Category c2 = new Category { CategoryId =2,CategoryName = "Category 2" };
            Category c3 = new Category { CategoryId =3,CategoryName = "Category 3" };
            Category c4 = new Category { CategoryId = 4,CategoryName = "Category 4" };
            

            Supplier s1 = new Supplier { SupplierId = 1,SupplierName = "Supplier 1" };
            Supplier s2 = new Supplier { SupplierId = 2,SupplierName = "Supplier 2" };
            Supplier s3 = new Supplier { SupplierId = 3,SupplierName = "Supplier 3" };
            

            Product p1 = new Product { ProductId = 1,ProductName = "Product 1",Price=100,Category=c1,Supplier=s1};
            Product p2 = new Product { ProductId = 2,ProductName = "Product 2",Price=190,Category=c1, Supplier=s1};
            Product p3 = new Product { ProductId = 3,ProductName = "Product 3",Price = 88,Category=c2,Supplier=s3 };
            Product p4 = new Product { ProductId = 4,ProductName = "Product 4",Price=29, Category=c3,Supplier=s1};
            Product p5 = new Product { ProductId = 5,ProductName = "Product 5",Price=56, Category=c1,Supplier=s2};
            Product p6 = new Product { ProductId = 6,ProductName = "Product 6",Price=123,Category=c3,Supplier=s3};



            db.Categories.Add(c1);
            db.Categories.Add(c2);
            db.Categories.Add(c3);
            db.Categories.Add(c4);


            db.Suppliers.Add(s1);
            db.Suppliers.Add(s2);
            db.Suppliers.Add(s3);


            db.Products.Add(p1);
            db.Products.Add(p2);
            db.Products.Add(p3);
            db.Products.Add(p4);
            db.Products.Add(p5);
            db.Products.Add(p6);

           
            

            db.SaveChanges();

        }
    }
}
