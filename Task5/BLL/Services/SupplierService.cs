using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL_EF.Entities;
using DAL_EF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SupplierService:ISupplierService
    {
        IUnitOfWork Database { get; set; }

        public SupplierService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<SupplierDTO> GetSuppliers()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Supplier, SupplierDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Supplier>, List<SupplierDTO>>(Database.Suppliers.GetAll());
        }

        public SupplierDTO GetSupplierById(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Supplier, SupplierDTO>()).CreateMapper();
            return mapper.Map<Supplier, SupplierDTO>(Database.Suppliers.Get(p => p.SupplierId == id).First());
        }

        public void CreateSupplier(SupplierDTO supplierDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Supplier, SupplierDTO>()).CreateMapper();
            Supplier newSupplier = mapper.Map<Supplier>(supplierDTO);
            Database.Suppliers.Create(newSupplier);
            Database.Save();
        }
        public void UpdateSupplier(SupplierDTO supplierDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Supplier, SupplierDTO>()).CreateMapper();
            Supplier newSupplier = mapper.Map<Supplier>(supplierDTO);
            Database.Suppliers.Update(newSupplier);
            Database.Save();
        }

        public void DeleteSupplier(int id)
        {
            Database.Suppliers.Delete(id);
            Database.Save();
        }

        public SupplierDTO GetSupplierByName(string supplierName)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Supplier, SupplierDTO>()).CreateMapper();
            return mapper.Map<Supplier, SupplierDTO>(Database.Suppliers.Get(p => p.SupplierName == supplierName).First());
        }

        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
