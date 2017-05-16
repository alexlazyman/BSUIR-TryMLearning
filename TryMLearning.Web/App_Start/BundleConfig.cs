using System.Web.Optimization;
using BundleTransformer.Core.Builders;
using BundleTransformer.Core.Orderers;
using BundleTransformer.Core.Transformers;
using TryMLearning.Web.Bundles;

namespace TryMLearning.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            var styleTransformer = new StyleTransformer();

            var commonStyleBundle = new Bundle("~/content/common-css");
            commonStyleBundle.Transforms.Add(styleTransformer);
            commonStyleBundle.Builder = new NullBuilder();
            commonStyleBundle.Orderer = new NullOrderer();

            commonStyleBundle
                .Include(
                    "~/libraries/bootstrap/dist/css/bootstrap.css",
                    "~/libraries/angular-bootstrap/ui-bootstrap-csp.css")
                .IncludeDirectory("~/content/styles", "*.less", true)
                .IncludeDirectory("~/app", "*.less", true);

            bundles.Add(commonStyleBundle);

            var commonJsBundle = new ScriptBundle("~/content/common-js");
            commonJsBundle
                .Include(
                    "~/libraries/bootstrap/dist/js/bootstrap.js",
                    "~/libraries/jquery/dist/jquery.js",
                    "~/libraries/lodash/lodash.js",
                    "~/libraries/moment/moment.js",
                    "~/libraries/angular/angular.js",
                    "~/libraries/chart.js/dist/Chart.js",
                    "~/libraries/angular-chart.js/dist/angular-chart.js",
                    "~/libraries/angular-base64/angular-base64.js",
                    "~/libraries/angular-bootstrap/ui-bootstrap-tpls.js",
                    "~/libraries/angular-bootstrap/ui-bootstrap.js",
                    "~/libraries/angular-spinner/dist/angular-spinner.js",
                    "~/libraries/angular-cookies/angular-cookies.js",
                    "~/libraries/query-string/query-string.js",
                    "~/libraries/angular-oauth2/dist/angular-oauth2.js",
                    "~/libraries/angular-ui-router/release/angular-ui-router.js");

            var clientJsBundle = new ScriptBundle("~/content/client-js");
            clientJsBundle
                .Include("~/app/client.js")
                .IncludeDirectory("~/app/shared", "*.js", true)
                .IncludeDirectory("~/app/client", "*.js", true);

            bundles.Add(commonJsBundle);
            bundles.Add(clientJsBundle);

            bundles.Add(new AngularJsHtmlBundle("~/content/common-html", "app")
                .IncludeDirectory("~/app", "*.html", true));
        }
    }
}