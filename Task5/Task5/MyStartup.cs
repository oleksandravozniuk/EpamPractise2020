using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class MyStartup
    {
        public static ServiceProvider serviceProvider;
        static MyStartup()
        {
            //var service = new ServiceCollection();

            //ServiceExtentions.ConfigureUnitOfWork(service);
            //ServiceExtentions.ConfigureAutoMapper(service);
            //ServiceExtentions.ConfigureBLLServices(service);

            //serviceProvider = service.BuildServiceProvider();
        }
    }
}
