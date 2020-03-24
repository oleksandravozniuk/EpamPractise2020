using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_EF.Repositories
{
    class ProductRepository
    {
        private TheatreContext db;

        public ProductRepository(TheatreContext context)
        {
            this.db = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products.Include(o => o.Ticket);
        }

        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public void Create(Product order)
        {
            db.Products.Add(order);
        }

        public void Update(Product order)
        {
            db.Entry(order).State = EntityState.Modified;
        }
        public IEnumerable<Product> Find(Func<Product, Boolean> predicate)
        {
            return db.Products.Include(o => o.Ticket).Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Product order = db.Products.Find(id);
            if (order != null)
                db.Products.Remove(order);
        }
    }
}
