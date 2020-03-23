using BLL.Interfaces;
using BLL.Services;
using DAL_ADONET.Interfaces;
using DAL_ADONET;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using DAL_ADONET.TDG;

namespace BLL.Infrastructure
{
    class ServiceModule:NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope().WithConstructorArgument(connectionString);
            Bind<ICategoryService>().To<CategoryService>().InSingletonScope();
            Bind<IProductService>().To<ProductService>().InSingletonScope();
            Bind<ISupplierService>().To<SupplierService>().InSingletonScope();
        }
    }
}
