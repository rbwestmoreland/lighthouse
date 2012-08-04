using System.Web;
using System.Web.Optimization;

namespace Lighthouse.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            var cssBundle = new Bundle("~/content/css", new CssMinify());
            cssBundle.Include("~/content/bootstrap.min.css");
            cssBundle.Include("~/content/bootstrap-custom.css");
            cssBundle.Include("~/content/bootstrap-responsive.min.css");
            cssBundle.Include("~/content/lighthouse.base.css");
            bundles.Add(cssBundle);

            var javascriptBundle = new Bundle("~/scripts/javascript", new JsMinify());
            javascriptBundle.Include("~/scripts/bootstrap.min.js");
            javascriptBundle.Include("~/scripts/lighthouse.js");
            bundles.Add(javascriptBundle);

            BundleTable.EnableOptimizations = true;
        }
    }
}