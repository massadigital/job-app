using JobApp.App.Core.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobApp.DependencyInjection;
using Unity;
using Unity.Lifetime;
using JobApp.App.Core.Interfaces.Handlers;
using JobApp.App.Core.Maps;
using SimpleMapper.Core;
using JobApp.App.Core.Models;
using JobApp.Domain.Models;
using JobApp.Common.Data;

namespace JobApp.App.Core.DependencyInjection
{
    public static class MapsInjection
    {
        public static void Configure(IUnityContainer container)
        {
            container.RegisterType<IMapper<PersonApp, Person>, PersonAppMap>(new HierarchicalLifetimeManager());
            container.RegisterType<IMapper<Person, PersonApp>, PersonMap>(new HierarchicalLifetimeManager());
            container.RegisterType<IMapper<DataQuery<Person>, DataQuery<PersonApp>>, PersonDataQueryMap>(new HierarchicalLifetimeManager());
            container.RegisterType<IMapper<DataQuery<PersonApp>, DataQuery<Person>>, PersonAppDataQueryMap>(new HierarchicalLifetimeManager());
            container.RegisterType<IMapper<DataResult<Person>, DataResult<PersonApp>>, PersonDataResultMap>(new HierarchicalLifetimeManager());
        }
    }
}
