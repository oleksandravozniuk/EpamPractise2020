using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_ADONET.Interfaces
{
    public interface IUnitOfWork
    {
        IProductTDG Product { get; }
        ISupplierTDG Supplier { get; }
        ICategoryTDG Category { get; }

        void Save();
    }
}
