using System.Web.Mvc;

namespace Lighthouse.Web
{
    public class ControllerFactoryConfig
    {
        public static void RegisterFactory(IControllerFactory controllerFactory)
        {
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}