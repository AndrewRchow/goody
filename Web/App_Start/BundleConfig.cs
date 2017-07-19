using System.Web;
using System.Web.Optimization;

namespace Goody.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;
            bundles.Add(new ScriptBundle("~/bundles/jquery",
                "https://cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.min.js")
                .Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval",
                "https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.16.0/jquery.validate.min.js")
                .Include("~/Scripts/jquery.validate.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryvalunobtrusive",
                "https://cdnjs.cloudflare.com/ajax/libs/jquery-validation-unobtrusive/3.2.6/jquery.validate.unobtrusive.min.js")
                .Include("~/Scripts/jquery.validate.unobtrusive.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr",
                "https://cdnjs.cloudflare.com/ajax/libs/modernizr/2.8.3/modernizr.min.js")
                .Include("~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap",
                "https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/js/bootstrap.min.js")
                .Include("~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/respond",
                "https://cdnjs.cloudflare.com/ajax/libs/respond.js/1.4.2/respond.min.js")
                .Include("~/Scripts/respond.js"));

            // Angular stuff
            bundles.Add(new ScriptBundle("~/bundles/angular",
                "https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.6.5/angular.min.js")
                .Include("~/Scripts/angular.min.js"));

            bundles.Add(new StyleBundle("~/Content/css",
                "https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/css/bootstrap.min.css")
                .Include("~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/sitecss")
                .Include("~/Content/site.css"));
        }
    }
}
