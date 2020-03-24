using DAL_ADONET.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL_ADONET.TDG
{
    public class UnitOfWork:IUnitOfWork
    {
        private SqlConnection connection;
        private IProductTDG product;
        private ICategoryTDG category;
        private ISupplierTDG supplier;

        public UnitOfWork(string connectionString)
        {
            this.connection = new SqlConnection(connectionString);
        }
        public IProductTDG Products
        {
            get
            {
                if (product == null)
                {
                    product = new ProductTDG(connection);
                }
                return product;
            }
        }

        public ISupplierTDG Suppliers
        {
            get
            {
                if (supplier == null)
                {
                    supplier = new SupplierTDG(connection);
                }
                return supplier;
            }
        }

        public ICategoryTDG Categories
        {
            get
            {
                if (category == null)
                {
                    category = new CategoryTDG(connection);
                }
                return category;
            }
        }

       

        public void Dispose(bool v)
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            
        }
    }
}
