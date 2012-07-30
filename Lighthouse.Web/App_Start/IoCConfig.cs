using System.Web;
using System.Web.Optimization;
using TinyIoC;
using System.Web.Mvc;
using Lighthouse.Web.Controllers;
using Lighthouse.Controllers.Factories;
using Lighthouse.Controllers.DependencyResolvers;

namespace Lighthouse.Web
{
    public class IoCConfig
    {
        public static TinyIoCContainer Register()
        {
            var container = new TinyIoCContainer();

            //Mvc Framework
            container.Register<IControllerFactory, TinyIocControllerFactory>();
            container.Register<System.Web.Http.Dependencies.IDependencyResolver, TinyIocDependencyResolver>();

            //Mvc Controllers
            container.Register<IController, HomeController>("Home").AsMultiInstance();

            //WebApi Controllers
            //container.Register<ValuesController>().AsMultiInstance();

            //Domain

            return container;
        }
    }
}