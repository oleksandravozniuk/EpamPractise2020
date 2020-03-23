﻿using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTOs;

namespace BLL.Interfaces
{
    interface ISupplierService
    {
        void Create(SupplierDTO supplier);
        void Update(SupplierDTO supplier);
        void Delete(int supplierId);

        SupplierDTO GetById(int id);

        IEnumerable<SupplierDTO> GetAll();
        IEnumerable<SupplierDTO> GetSuppliersByCategory(string category);
        IEnumerable<SupplierDTO> GetSuppliersWhereCategoryMax();
    }
}
