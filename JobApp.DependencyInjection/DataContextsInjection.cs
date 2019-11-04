using JobApp.Data.Contexts;
using Unity;
using Unity.Lifetime;

namespace JobApp.DependencyInjection
{
    public class DataContextsInjection
    {
        public static void Configure(IUnityContainer container)
        {
            container.RegisterType<JobAppContext, JobAppMsSqlContext>(new HierarchicalLifetimeManager());
        }
    }
}
