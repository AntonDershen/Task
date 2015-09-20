using System.Web;
using System.Web.Optimization;

namespace WebApplication
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                      "~/Scripts/jquery-1.10.2.min.js",
                      "~/Scripts/jquery-migrate-1.2.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                      "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                      "~/Scripts/respond.js",
                      "~/Scripts/style-script.js"));

            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                      "~/Content/style.css"));
        }
    }
}
