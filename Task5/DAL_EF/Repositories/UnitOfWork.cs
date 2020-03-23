﻿using DAL_EF.EF;
using DAL_EF.Entities;
using DAL_EF.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_EF.Repositories
{
    class UnitOfWork:IUnitOfWork
    {
        private StoreContext db;
        private ProductRepository productRepository;
        private CategoryRepository categoryRepository;
        private SupplierRepository supplierRepository;


        public EFUnitOfWork(string connectionString)
        {
            db = new StoreContext(connectionString);
        }
        public IRepository<Product> Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(db);
                return productRepository;
            }
        }

        public IRepository<Category> Categorys
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(db);
                return categoryRepository;
            }
        }



        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}