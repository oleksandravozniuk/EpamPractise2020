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
    public class ProductOrderRepository : IRepository<ProductOrder>
    {
        private StoreContext db;

        public ProductOrderRepository(StoreContext context)
        {
            this.db = context;
        }

        public IEnumerable<ProductOrder> GetAll()
        {
            return db.ProductOrders.AsNoTracking().Include(c => c.Product).Include(c=>c.Order).AsNoTracking();
        }

        public void Create(ProductOrder order)
        {
            db.ProductOrders.Add(order);
        }

        public void Update(ProductOrder order)
        {

            db.Entry(order).State = EntityState.Modified;

        }


        public void Detach(ProductOrder order)
        {
            db.Entry(order).State = EntityState.Detached;
        }
        public IEnumerable<ProductOrder> Get(Func<ProductOrder, Boolean> predicate)
        {
            return db.ProductOrders.AsNoTracking().Include(c=>c.Order).Include(c=>c.Product).Where(predicate);
        }
        public void Delete(int id)
        {
            ProductOrder order = db.ProductOrders.Find(id);
            if (order != null)
                db.ProductOrders.Remove(order);
        }
    }
}
