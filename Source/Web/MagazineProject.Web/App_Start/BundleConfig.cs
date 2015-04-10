namespace MagazineProject.Web
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterScriptBundles(bundles);
            RegisterContentBundles(bundles);

            BundleTable.EnableOptimizations = false;
        }

        private static void RegisterContentBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.cerulean.css",
                "~/Content/font-awesome.css",
                "~/Content/PagedList.css",
                "~/Content/themes/base/all.css",
                "~/Content/fileinput.css",
                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/grid").Include(
                "~/Content/Gridmvc.css"));

        }

        private static void RegisterScriptBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryAjax").Include(
            "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*",
                "~/Scripts/jquery-ui-{version}.js",
                "~/Scripts/search.js",
                "~/Scripts/extensions.js"));

            bundles.Add(new ScriptBundle("~/bundles/uploadImage").Include(
           "~/Scripts/fileinput.js"));

            bundles.Add(new ScriptBundle("~/bundles/gridmvc").Include(
                "~/Scripts/gridmvc.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));
        }
    }
}