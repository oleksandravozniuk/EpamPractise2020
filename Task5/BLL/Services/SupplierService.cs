using AutoMapper;
using BLL.DTOs;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL_ADONET.Entities;
using DAL_ADONET.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    class SupplierService:ISupplierService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public SupplierService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork != null)
                this.unitOfWork = unitOfWork;

            MapperConfiguration config = new MapperConfiguration(con =>
            {
                con.CreateMap<SupplierDTO, Supplier>();
                con.CreateMap<Supplier, SupplierDTO>();

                con.CreateMap<ProductDTO, Product>();
                con.CreateMap<Product, ProductDTO>();
            }
            );

            mapper = config.CreateMapper();
        }

        public void Create(SupplierDTO supplier)
        {
            if (supplier == null)
                throw new ValidationException("Cannot create the nullable instance of Supplier");

            try
            {
                Supplier newSupplier = mapper.Map<Supplier>(supplier);
                unitOfWork.Supplier.Add(newSupplier);
                unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new ValidationException("Cannot create an instance of Supplier", ex);
            }
        }

        public void Update(SupplierDTO supplier)
        {
            try
            {
                Supplier newSupplier = mapper.Map<Supplier>(supplier);
                unitOfWork.Supplier.Update(newSupplier);
                unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new ValidationException("Cannot update an instance of Supplier", ex);
            }
        }

        public void Delete(int supplierId)
        {
            try
            {
                unitOfWork.Supplier.Delete(supplierId);
                unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new ValidationException("Cannot delete an instance of Supplier", ex);
            }
        }

        public SupplierDTO GetById(int id)
        {
            SupplierDTO supplierDTO;
            try
            {
                supplierDTO = mapper.Map<SupplierDTO>(unitOfWork.Supplier.GetById(id));
            }
            catch (Exception ex)
            {
                throw new ValidationException("Cannot get an instance of Supplier", ex);
            }

            return supplierDTO;
        }

        public IEnumerable<SupplierDTO> GetAll()
        {
            IEnumerable<SupplierDTO> supplierDTOs;
            try
            {
                supplierDTOs = mapper.Map<IEnumerable<SupplierDTO>>(unitOfWork.Supplier.GetAll());
            }
            catch (Exception ex)
            {
                throw new ValidationException("Cannot get an instances of Supplier", ex);
            }

            return supplierDTOs;
        }

        public IEnumerable<SupplierDTO> GetSuppliersByCategory(string category)
        {
            try
            {
                var products = mapper.Map<IEnumerable<ProductDTO>>(
                 unitOfWork.Product.GetAll().Where(x => x.Category.CategoryName == category).ToList()
             );
                var suppliers = products.Select(x => x.Supplier).Distinct().ToList();
                return suppliers;
            }
            catch (Exception ex)
            {
                throw new ValidationException("Cannot get all an instances of Supplier", ex);
            }
        }

        public IEnumerable<SupplierDTO> GetSuppliersWhereCategoryMax()
        {
            try
            {
                var tableRes = unitOfWork.Product.GetAll().
                    Select(x => new { Supp = x.Supplier.SupplierId, Cat = x.Category.CategoryId }).Distinct().
                    GroupBy(x => x.Supp).
                    Select(g => new { Sup = g.Key, Count = g.Count() });

                var maxRes = tableRes.Max(x => x.Count);

                var supRes = tableRes.Where(x => x.Count == maxRes).Select(x => x.Sup);

                return mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierDTO>>(
                    unitOfWork.Supplier.GetAll().Where(x => supRes.Contains(x.SupplierId)));
            }
            catch (Exception ex)
            {
                throw new ValidationException("Cannot get all an instances of Supplier", ex);
            }
        }
    }
}
