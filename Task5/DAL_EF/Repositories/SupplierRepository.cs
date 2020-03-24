using DAL_EF.Context;
using DAL_EF.Entities;
using DAL_EF.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Create(Supplier supplier)
        {
            db.Suppliers.Add(supplier);
        }

        public void Update(Supplier supplier)
        {
            db.Entry(supplier).State = EntityState.Modified;
        }
        public IEnumerable<Supplier> Get(Func<Supplier, Boolean> predicate)
        {
            return db.Suppliers.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier != null)
                db.Suppliers.Remove(supplier);
        }
    }
}
