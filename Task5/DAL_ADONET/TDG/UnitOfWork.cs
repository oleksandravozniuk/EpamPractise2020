using DAL_ADONET.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL_ADONET.TDG
{
    public class UnitOfWork
    {
        private SqlConnection connection;
        private IProductTDG product;
        private ICategoryTDG category;
        private ISupplierTDG supplier;

        public UnitOfWork(string connectionString)
        {
            this.connection = new SqlConnection(connectionString);
        }
        public IProductTDG Product
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

        public ISupplierTDG Supplier
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

        public ICategoryTDG Category
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

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
