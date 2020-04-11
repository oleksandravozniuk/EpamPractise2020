using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private StoreContext db;

        public ProductRepository(StoreContext context)
        {
            this.db = context;
        }

        public IEnumerable<Product> GetAll()
        {
            //db.Configuration.ProxyCreationEnabled = false;
            return db.Products.AsNoTracking();
        }

        public void Create(Product product)
        {
            db.Products.Add(product);
        }

        public void Update(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
        }

        public void Detach(Product product)
        {
            db.Entry(product).State = EntityState.Detached;
        }
        public IEnumerable<Product> Get(Func<Product, Boolean> predicate)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Products.AsNoTracking().Where(predicate);
        }
        public void Delete(int id)
        {
            Product product = db.Products.Find(id);
            if (product != null)
                db.Products.Remove(product);
        }
    }
}
