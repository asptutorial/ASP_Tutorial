using System.Web;
using System.Web.Optimization;

namespace BootstrapSiteLCD
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Bootstrap
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/jquery-1.9.1.js"));
            
            // Bootstrap Styles
            bundles.Add(new StyleBundle("~/css/bootstrap").Include(
                "~/css/bootstrap.css",
                "~/css/modern-business.css"));

            // jQueryRuntime
            bundles.Add(new ScriptBundle("~/bundles/jQueryRuntime").Include(
                "~/Scripts/bundles/jQueryRuntime/runtimePartial.js"));
        }
    }
}
