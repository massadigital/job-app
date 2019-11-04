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

namespace JobApp.App.Core.DependencyInjection
{
    public static class HandlersInjection
    {
        public static void Configure(IUnityContainer container)
        {
            container.RegisterType<ILinqChallengeHandler, LinqChallengeHandler>(new HierarchicalLifetimeManager());
            container.RegisterType<ILevelHandler, LevelHandler>(new HierarchicalLifetimeManager());
            container.RegisterType<IPersonHandler, PersonHandler>(new HierarchicalLifetimeManager());
        }
    }
}
