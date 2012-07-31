using System.Configuration;
using System.Web.Mvc;
using Lighthouse.Controllers.DependencyResolvers;
using Lighthouse.Controllers.Factories;
using Lighthouse.Web.Controllers;
using TinyIoC;

namespace Lighthouse.Web
{
    public class IoCConfig
    {
        public static TinyIoCContainer Register()
        {
            var container = new TinyIoCContainer();

            //AppSettings
            var clientId = ConfigurationManager.AppSettings["apphp-oauth-client-id"];
            var clientSecretKey = ConfigurationManager.AppSettings["apphb-oauth-client-secretkey"];
            var callbackUrl = ConfigurationManager.AppSettings["apphb-oauth-client-callback"];

            //Mvc Framework
            container.Register<IControllerFactory, TinyIocControllerFactory>();
            container.Register<System.Web.Http.Dependencies.IDependencyResolver, TinyIocDependencyResolver>();

            //Mvc Controllers
            container.Register<IController>((c, p) => new OAuthController(clientId, clientSecretKey, callbackUrl), "OAuth");
            container.Register<IController, HomeController>("Home").AsMultiInstance();

            //WebApi Controllers
            //container.Register<ValuesController>().AsMultiInstance();

            //Domain

            return container;
        }
    }
}