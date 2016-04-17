using System.Web;
using System.Web.Optimization;

namespace ODataLab
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/node_modules/angular/angular.js")
                .Include("~/node_modules/angular-bootstrap/ui-bootstrap.js")
                .Include("~/node_modules/angular-resource/angular-resource.js")
                .Include("~/node_modules/angular-messages/angular-messages.js")
                .Include("~/node_modules/angular-animate/angular-animate.js")
                .Include("~/node_modules/angular-route/angular-route.js")
                .Include("~/Content/lib/kendo/kendo.all.min.js")
                .IncludeDirectory("~/Content/js","*.js", true));

            

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/css/kendo.common.min.css",
                      "~/Content/css/kendo.default.min.css"));
        }
    }
}
