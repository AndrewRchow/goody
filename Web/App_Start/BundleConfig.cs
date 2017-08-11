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

            // Angular Animate
            bundles.Add(new ScriptBundle("~/bundles/angular-animate",
                "https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.6.5/angular-animate.min.js")
                .Include("~/Scripts/angularjs/angular-animate.js"));

            // Angular Aria
            bundles.Add(new ScriptBundle("~/bundles/angular-aria",
                "https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.6.5/angular-aria.min.js")
                .Include("~/Scripts/angularjs/angular-aria.js"));

            // Angular Cookies
            bundles.Add(new ScriptBundle("~/bundles/angular-cookies",
                "https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.6.5/angular-cookies.min.js")
                .Include("~/Scripts/angularjs/angular-cookies.js"));

            // Angular Loader
            bundles.Add(new ScriptBundle("~/bundles/angular-loader",
                "https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.6.5/angular-loader.min.js")
                .Include("~/Scripts/angularjs/angular-loader.js"));

            // Angular Message Format
            bundles.Add(new ScriptBundle("~/bundles/angular-message-format",
                "https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.6.5/angular-message-format.min.js")
                .Include("~/Scripts/angularjs/angular-message-format.js"));

            // Angular Message
            bundles.Add(new ScriptBundle("~/bundles/angular-messages",
                "https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.6.5/angular-messages.min.js")
                .Include("~/Scripts/angularjs/angular-messages.js"));

            // Angular Parse
            bundles.Add(new ScriptBundle("~/bundles/angular-parse-ext",
                "https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.6.5/angular-parse-ext.min.js")
                .Include("~/Scripts/angularjs/angular-parse-ext.js"));

            // Angular Resource
            bundles.Add(new ScriptBundle("~/bundles/angular-resource",
                "https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.6.5/angular-resource.min.js")
                .Include("~/Scripts/angularjs/angular-resource.js"));

            // Angular Route
            bundles.Add(new ScriptBundle("~/bundles/angular-route",
                "https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.6.5/angular-route.min.js")
                .Include("~/Scripts/angularjs/angular-route.js"));

            // Angular Sanitize
            bundles.Add(new ScriptBundle("~/bundles/angular-sanitize",
                "https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.6.5/angular-sanitize.min.js")
                .Include("~/Scripts/angularjs/angular-sanitize.js"));

            // Angular Touch
            bundles.Add(new ScriptBundle("~/bundles/angular-touch",
                "https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.6.5/angular-touch.min.js")
                .Include("~/Scripts/angularjs/angular-touch.js"));

            // Angular JS
            bundles.Add(new ScriptBundle("~/bundles/angular",
                "https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.6.5/angular.min.js")
                .Include("~/Scripts/angularjs/angular.js"));

            // Angular JS CSS
            bundles.Add(new StyleBundle("~/Content/angularjs-css",
                "https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.6.5/angular-csp.css")
                .Include("~/Content/angularjs/angular-csp.css"));


            bundles.Add(new StyleBundle("~/Content/css",
                "https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/css/bootstrap.min.css")
                .Include("~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/sitecss")
                .Include("~/Content/site.css"));
        }
    }
}
