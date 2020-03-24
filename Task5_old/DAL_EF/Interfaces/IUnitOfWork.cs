using DAL_EF.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_EF.Interfaces
{
    interface IUnitOfWork:IDisposable
    {
        IRepository<Product> Products { get; }
        IRepository<Category> Categories { get; }
        IRepository<Supplier> Suppliers { get; }
        void Save();
    }
}
