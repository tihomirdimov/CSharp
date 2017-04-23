﻿using System.Web;
using System.Web.Optimization;

namespace PersonalFinanceManager
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/scripts/bootstrap.js",
                      "~/Content/scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap/bootstrap.css",
                      "~/Content/css/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/unobtrusive").Include(
                "~/Content/scripts/jquery.unobtrusive*",
                "~/Content/scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/services").Include(
                "~/Content/scripts/js-service-scripts.js"));
        }
    }
}
