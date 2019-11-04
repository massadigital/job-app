using JobApp.Domain.Services;
using JobApp.Interfaces.Domain.Services;
using Unity;
using Unity.Lifetime;

namespace JobApp.DependencyInjection
{
    public class DomainServicesInjection
    {
        public static void Configure(IUnityContainer container)
        {
            container.RegisterType<ILinqChallengeService, LinqChallengeService>(new HierarchicalLifetimeManager());
            container.RegisterType<ILevelService, LevelService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPersonService, PersonService>(new HierarchicalLifetimeManager());
        }
    }
}
