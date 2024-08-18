using MiniProject.Models;
using System.Web;
using System.Web.Optimization;
using System.Web.UI.WebControls;

namespace MiniProject
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"
                        ));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js", "~/Scripts/bootstrap.min.js",
                      "~/Scripts/jquery-3.3.1.min.js",
                      "~/Scripts/jquery.countdown.min.js",
                      "~/Scripts/jquery.magnific-popup.min.js",
                      "~/Scripts/jquery.nice-select.min.js",
                      "~/Scripts/jquery.nicescroll.min.js",
                      "~/Scripts/jquery.slicknav.js",
                      "~/Scripts/main.js",
                      "~/Scripts/mixitup.min.js",
                      "~/Scripts/owl.carousel.min.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/normalize.css",
                      "~/Content/vendor.css"
                    ));
        
        }
    }
}

