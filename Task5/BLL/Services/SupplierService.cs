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
       

        private readonly IMapper supplierMapper;

        public SupplierService(IUnitOfWork uow)
        {
            if (uow != null)
                this.Database = uow;


            MapperConfiguration configSupplier = new MapperConfiguration(con =>
            {
                con.CreateMap<Supplier, SupplierDTO>();
                con.CreateMap<SupplierDTO, Supplier>();
            });
            supplierMapper = configSupplier.CreateMapper();

        }

        public IEnumerable<SupplierDTO> GetSuppliers()
        {
            return supplierMapper.Map<IEnumerable<Supplier>, List<SupplierDTO>>(Database.Suppliers.GetAll().ToList());
        }

        public SupplierDTO GetSupplierById(int? id)
        {
            return supplierMapper.Map<Supplier, SupplierDTO>(Database.Suppliers.Get(p => p.SupplierId == id).First());
        }

        public void CreateSupplier(SupplierDTO supplierDTO)
        {
            Supplier newSupplier = supplierMapper.Map<Supplier>(supplierDTO);
            Database.Suppliers.Create(newSupplier);
            Database.Save();
        }
        public void UpdateSupplier(SupplierDTO supplierDTO)
        {
            Supplier newSupplier = supplierMapper.Map<Supplier>(supplierDTO);
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
            return supplierMapper.Map<Supplier, SupplierDTO>(Database.Suppliers.Get(p => p.SupplierName == supplierName).First());
        }
        public IEnumerable<SupplierDTO> GetSuppliersByCategory(string categoryName)
        {

            var products = Database.Products.GetAll().Where(p => p.Category.CategoryName == categoryName);
            
            var suppliers = products.Select(s => s.Supplier);

            return supplierMapper.Map<IEnumerable<Supplier>, List<SupplierDTO>>(suppliers.ToList());
        }

        public IEnumerable<SupplierDTO> GetSuppliersByMaxCategory()
        {
            List<SupplierDTO> suppliers = new List<SupplierDTO>();

            var group = Database.Products.GetAll().GroupBy(p => p.Category)
                        .Select(g => new
                        {
                            Name = g.Key.CategoryName,
                            Count = g.Count(),
                            Suppliers = g.Select(p => p.Supplier).Distinct()
                        }).OrderByDescending(g=>g.Count).First();
            
                foreach (SupplierDTO supplier in supplierMapper.Map<IEnumerable<Supplier>,List<SupplierDTO>>(group.Suppliers))
                    suppliers.Add(supplier);
            return suppliers;
        }
        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
