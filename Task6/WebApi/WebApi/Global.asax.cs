using BLL.Infrastructure;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Epam6;Integrated Security=True";
            //NinjectModule storeModule = new StoreModule();
            //NinjectModule serviceModule = new ServiceModule(connectionString);
            //var kernel = new StandardKernel(storeModule, serviceModule);
        }
    }
}
