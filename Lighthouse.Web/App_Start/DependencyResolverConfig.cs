using System.Web.Http;
using System.Web.Http.Dependencies;

namespace Lighthouse.Web
{
    public class DependencyResolverConfig
    {
        public static void RegisterResolver(IDependencyResolver dependencyResolver)
        {
            GlobalConfiguration.Configuration.DependencyResolver = dependencyResolver;
        }
    }
}