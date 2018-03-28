using System.Web;
using System.Web.Optimization;

namespace StudentWebApplication
{
    public class BundleConfig
    {
        // Weitere Informationen zu Bundling finden Sie unter "http://go.microsoft.com/fwlink/?LinkId=301862"
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Verwenden Sie die Entwicklungsversion von Modernizr zum Entwickeln und Erweitern Ihrer Kenntnisse. Wenn Sie dann
            // für die Produktion bereit sind, verwenden Sie das Buildtool unter "http://modernizr.com", um nur die benötigten Tests auszuwählen.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // runtimePartial
            bundles.Add(new ScriptBundle("~/plugins/jqueryRuntime").Include(
                    "~/Scripts/plugins/jqueryRuntime/runtimePartial.js"));


            // jQueryUnobtrusive
            bundles.Add(new ScriptBundle("~/bundles/jqueryunobtrusive").Include(
                "~/Scripts/jqueryunobtrusive-ajax.js",
                "~/Scripts/jqueryunobtrusive-ajax.min.js"));
        }
    }
}
