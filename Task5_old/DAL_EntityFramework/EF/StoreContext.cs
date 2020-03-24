using DAL_EF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace DAL_EF.EF
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

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext db)
        {

            db.SaveChanges();

        }
    }
}

