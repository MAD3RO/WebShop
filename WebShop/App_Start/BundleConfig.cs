﻿using System.Web;
using System.Web.Optimization;

namespace WebShop
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
            "~/Scripts/jquery-3.5.1.min.js",
            "~/Scripts/bootstrap.min.js",
            "~/Scripts/jquery.validate.min.js",
            "~/Scripts/jquery.validate.unobtrusive.min.js",
            "~/Scripts/jquery.unobtrusive-ajax.min.js",
            "~/Scripts/slick.min.js",
            "~/Scripts/jquery.zoom.min.js",
            "~/Scripts/scroll.js",
            "~/Scripts/move-top.js",
            "~/Scripts/easing.js",
            "~/Scripts/main.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/admin-bundle").Include(
            "~/Areas/Admin/Scripts/jquery.min.js",
            "~/Areas/Admin/Scripts/bootstrap.bundle.min.js",
            "~/Areas/Admin/Scripts/jquery.easing.min.js",
            "~/Areas/Admin/Scripts/admin.min.js",
            "~/Areas/Admin/Scripts/jquery.dataTables.min.js",
            "~/Areas/Admin/Scripts/dataTables.bootstrap4.min.js",
            "~/Areas/Admin/Scripts/datatables-demo.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                     "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/slick.css",
                      "~/Content/slick-theme.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/style.css"));

            bundles.Add(new StyleBundle("~/Areas/Admin/Content/css").Include(
                "~/Areas/Admin/Content/all.css",
                "~/Areas/Admin/Content/dataTables.bootstrap4.min.css",
                "~/Areas/Admin/Content/style.css"));
        }
    }
}
