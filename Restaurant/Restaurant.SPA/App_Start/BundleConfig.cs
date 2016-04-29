using System.Web;
using System.Web.Optimization;

namespace Restaurant.SPA
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                  "~/Scripts/angular.js",
                  "~/Scripts/angular-route.js",
                  "~/Scripts/angular-resource.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                     "~/app/app.js"));
            bundles.Add(new ScriptBundle("~/bundles/controllers").Include(
                    "~/app/controllers/HomeController.js",
                    "~/app/controllers/CategoryController.js",
                    "~/app/controllers/UserTypeController.js",
                    "~/app/controllers/FoodMenuController.js"));
            bundles.Add(new ScriptBundle("~/bundles/services").Include(
                      "~/app/services/CategoryService.js",
                      "~/app/services/UserTypeService.js",
                      "~/app/services/FoodMenuService.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
