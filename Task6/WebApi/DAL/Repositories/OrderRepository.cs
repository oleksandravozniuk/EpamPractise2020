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
    public class OrderRepository : IRepository<Order>
    {
        private StoreContext db;

        public OrderRepository(StoreContext context)
        {
            this.db = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders.AsNoTracking().AsNoTracking();
        }

        public void Create(Order order)
        {
            db.Orders.Add(order);
        }

        public void Update(Order order)
        {
            
            db.Entry(order).State = EntityState.Modified;
            
        }

       
        public void Detach(Order order)
        {
            db.Entry(order).State = EntityState.Detached;
        }
        public IEnumerable<Order> Get(Func<Order, Boolean> predicate)
        {
            return db.Orders.AsNoTracking().Where(predicate);
        }
        public void Delete(int id)
        {
            Order order = db.Orders.Find(id);
            if (order != null)
                db.Orders.Remove(order);
        }
    }
}
