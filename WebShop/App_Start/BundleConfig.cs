using System.Web;
using System.Web.Optimization;

namespace WebShop
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
            "~/Scripts/jquery-{version}.js",
            "~/Scripts/bootstrap.min.js",
            "~/Scripts/slick.min.js",
            "~/Scripts/nouislider.min.js",
            "~/Scripts/jquery.zoom.min.js",
            "~/Scripts/main.js",
            "~/Scripts/scroll.js",
            "~/Scripts/move-top.js",
            "~/Scripts/easing.js"
            //"~/Scripts/easyResponsiveTabs.js"
            //"~/Scripts/SmoothScroll.min.js"
            //"~/Scripts/creditly.js",
            //"~/Scripts/creditly2.js",
            //"~/Scripts/jquery.flexslider.js",
            //"~/Scripts/jquery.magnific-popup.js",
            //"~/Scripts/minicart.js",
            ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      //"~/Content/bootstrap-responsive.min.css",
                      "~/Content/slick.css",
                      "~/Content/slick-theme.css",
                      "~/Content/nouislider.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/style.css"));
            //"~/Content/creditly.css",
            //"~/Content/easy-responsive-tabs.css",
            //"~/Content/flexslider.css",
            //"~/Content/menu.css",
            //"~/Content/popuo-box.css",
            //"~/Content/site.css"));
        }
    }
}
