using System.Web;
using System.Web.Optimization;

namespace Lighthouse.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            var cssBundle = new Bundle("~/content/css", new CssMinify());
            bundles.Add(cssBundle);

            var javascriptBundle = new Bundle("~/scripts/javascript", new JsMinify());
            bundles.Add(javascriptBundle);

            BundleTable.EnableOptimizations = true;
        }
    }
}