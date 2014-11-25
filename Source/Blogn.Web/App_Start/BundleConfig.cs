using System.Web;
using System.Web.Optimization;
using Blogn.Constants;

namespace Blogn
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            Contract.IsNotNull(bundles, "bundles");

            bundles.Add(new ScriptBundle(Bundles.Scripts.JQuery).Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle(Bundles.Scripts.Validation).Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle(Bundles.Scripts.Modernizr).Include(
                        "~/Scripts/modernizr.2.8.3.minimal.js"));

            bundles.Add(new ScriptBundle(Bundles.Scripts.Bootstrap).Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle(Bundles.Styles.Theme).Include(
                      "~/Content/Bootstrap/bootstrap.css",
                      "~/Content/theme.css",
                      "~/Content/main.css"));

            BundleTable.EnableOptimizations = !BuildInfo.IsDebug;
        }
    }
}
