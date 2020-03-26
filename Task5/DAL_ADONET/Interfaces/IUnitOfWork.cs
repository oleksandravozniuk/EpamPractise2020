using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ADONET.Interfaces
{
    public interface IUnitOfWork
    {
        IProductTDG Products { get; }
        ISupplierTDG Suppliers { get; }
        ICategoryTDG Categories { get; }

        void Save();
        void Dispose();
    }
}
