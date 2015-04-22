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

            BundleTable.EnableOptimizations = true;
        }

        private static void RegisterContentBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.cerulean.css",
                "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/Grid").Include(
                "~/Content/Gridmvc.css"));

            bundles.Add(new StyleBundle("~/Content/file-input").Include(
               "~/Content/file-input.min.css"));

            bundles.Add(new StyleBundle("~/Content/PagedList").Include(
               "~/Content/PagedList.css"));

            bundles.Add(new StyleBundle("~/Content/jquery-search").Include(
               "~/Content/themes/base/all.css"));

            bundles.Add(new StyleBundle("~/Content/font-awesome").Include(
               "~/Content/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/Content/comment").Include(
               "~/Content/comment.css"));

            bundles.Add(new StyleBundle("~/Content/post-video").Include(
               "~/Content/post-video.css"));

        }

        private static void RegisterScriptBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryAjax").Include(
            "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/search").Include(
                "~/Scripts/jquery-ui-{version}.js",
                "~/Scripts/search.js"));

            bundles.Add(new ScriptBundle("~/bundles/val-extensions").Include(
            "~/Scripts/validation-extensions.js"));

            bundles.Add(new ScriptBundle("~/bundles/tinymce-client-val").Include(
            "~/Scripts/tinymce/tinymce-client-val.js"));

            bundles.Add(new ScriptBundle("~/bundles/uploadImage").Include(
           "~/Scripts/fileinput.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/gridmvc").Include(
                "~/Scripts/gridmvc.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/top").Include(
           "~/Scripts/to-top.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/respond.min.js"));
        }
    }
}