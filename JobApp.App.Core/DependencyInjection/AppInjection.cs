using JobApp.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace JobApp.App.Core.DependencyInjection
{
    public class AppInjection
    {
        public static void Configure(IUnityContainer container)
        {
            HandlersInjection.Configure(container);
            MapsInjection.Configure(container);
            DataContextsInjection.Configure(container);
            DataRepositoriesInjection.Configure(container);
            DomainServicesInjection.Configure(container);
        }
    }
}
