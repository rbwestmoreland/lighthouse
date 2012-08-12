using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Lighthouse.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "OAuth",
                url: "oauth/v2/{action}",
                defaults: new { controller = "OAuth", action = "Begin" }
            );

            routes.MapRoute(
                name: "Dashboard",
                url: "dashboard",
                defaults: new { controller = "Dashboard", action = "Default" }
            );

            routes.MapRoute(
                name: "Dashboard - Content",
                url: "dashboard/content",
                defaults: new { controller = "Dashboard", action = "Content" }
            );

            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}