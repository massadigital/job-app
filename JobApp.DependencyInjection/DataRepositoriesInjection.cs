using JobApp.Data.Repositories;
using JobApp.Interfaces.Data.Repositories;
using Unity;
using Unity.Lifetime;

namespace JobApp.DependencyInjection
{
    public class DataRepositoriesInjection
    {
        public static void Configure(IUnityContainer container)
        {
            container.RegisterType<IPersonRepository, PersonRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IJobRepository, JobRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICallRepository, CallRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IApplyRepository, ApplyRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ISkillRepository, SkillRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ILevelRepository, LevelRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IClaimRepository, ClaimRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPersonHasClaimRepository, PersonHasClaimRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IJobHasClaimRepository, JobHasClaimRepository>(new HierarchicalLifetimeManager());
        }
    }
}
