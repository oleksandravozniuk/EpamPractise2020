using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi
{
    public class StoreModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductService>();
            Bind<IOrderService>().To<OrderService>();
            Bind<IProductOrderService>().To<IProductOrderService>();

        }
    }
}