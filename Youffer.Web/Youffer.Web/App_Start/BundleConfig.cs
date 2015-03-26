using System.Web;
using System.Web.Optimization;

namespace Youffer.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                              "~/Scripts/jquery-{version}.js",
                              "~/Scripts/jquery-1.10.2.js",
                              "~/Scripts/jquery-ui.js",
                              "~/Scripts/Common.js",
                              "~/Scripts/date.js",
                              "~/Scripts/jquery.tablesorter.js",
                              "~/Scripts/chosen.jquery.js",
                              "~/Scripts/prism.js",
                              "~/Scripts/jquery.validate*",
                              "~/Scripts/jquery.unobtrusive-ajax.js",
                              "~/Scripts/jquery.validate.unobtrusive.min.js",
                              "~/Scripts/mvcfoolproof.unobtrusive.min.js",
                              "~/js/generic.js",
                              "~/Scripts/Common.js",
                              "~/js/ajaxCalls.js",
                              "~/js/businessLogic.js",
                              "~/Scripts/jquery.rating.js",
                              "~/Scripts/jquery.MetaData.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js",
                        "~/Scripts/mvcfoolproof.unobtrusive.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/Content/YoufferCss").Include(
                "~/Content/NewStyle.css",
                "~/Content/bootstrap.css",
                "~/Content/landing-page.css",
                "~/Content/font-awesome-4.2.0/css/font-awesome.css",
                "~/Content/jquery-ui.css",
                "~/Content/jquery.rating.css",
                "~/Content/chosen.css"
            ));

            //bundles.Add(new ScriptBundle("~/Content/ratingCss").Include(
            // "~/Content/jquery.rating.css"
            // ));

            bundles.Add(new ScriptBundle("~/bundles/ratingJS").Include(
                "~/Scripts/jquery.rating.js",
                "~/Scripts/jquery.MetaData.js"
                  ));

        }
    }
}
