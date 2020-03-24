using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISupplierService
    {
        IEnumerable<SupplierDTO> GetSuppliers();
        SupplierDTO GetSupplierById(int id);
        void CreateSupplier(SupplierDTO supplierDTO);
        void UpdateSupplier(SupplierDTO supplierDTO);
        SupplierDTO GetSupplierByName(string supplierName);
        void DeleteSupplier(int id);
        void Dispose();
    }
}
