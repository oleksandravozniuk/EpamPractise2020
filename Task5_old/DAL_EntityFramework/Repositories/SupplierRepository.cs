using DAL_EF.EF;
using DAL_EF.Entities;
using DAL_EF.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DAL_EF.Repositories
{
    public class SupplierRepository:IRepository<Supplier>
    {
        private StoreContext db;

        public SupplierRepository(StoreContext context)
        {
            this.db = context;
        }

        public IEnumerable<Supplier> GetAll()
        {
            return db.Suppliers;
        }

        public Supplier GetById(int id)
        {
            return db.Suppliers.Find(id);
        }

        public void Add(Supplier supplier)
        {
            db.Suppliers.Add(supplier);
        }

        public void Update(Supplier supplier)
        {
            db.Entry(supplier).State = EntityState.Modified;
        }
        public IEnumerable<Supplier> Find(Func<Supplier, Boolean> predicate)
        {
            return db.Suppliers.Include(o => o.SupplierName).Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier != null)
                db.Suppliers.Remove(supplier);
        }
    }
}
