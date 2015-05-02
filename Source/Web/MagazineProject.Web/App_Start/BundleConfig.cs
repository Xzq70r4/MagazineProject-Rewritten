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
            bundles.Add(new StyleBundle("~/Content/basic").Include(
                "~/Content/bootstrap.cerulean.min.css",
                "~/Content/font-awesome.min.css",
                "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/home-page").Include(
                 "~/Content/post-video.css",
                 "~/Content/PagedList.css",
                 "~/Content/themes/base/autocomplete.css",
                 "~/Content/themes/base/menu.css",
                 "~/Content/themes/base/theme.css"));

            bundles.Add(new StyleBundle("~/Content/post-details").Include(
                 "~/Content/comment.css",
                 "~/Content/PagedList.css"));

            bundles.Add(new StyleBundle("~/Content/Grid").Include(
                "~/Content/Gridmvc.css"));

            bundles.Add(new StyleBundle("~/Content/file-input").Include(
               "~/Content/file-input.min.css"));

            bundles.Add(new StyleBundle("~/Content/PagedList").Include(
               "~/Content/PagedList.css"));

            bundles.Add(new StyleBundle("~/Content/comment").Include(
               "~/Content/comment.css"));
        }

        private static void RegisterScriptBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/basic").Include(
                "~/Scripts/to-top.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/respond.min.js",
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/home-page").Include(
                "~/Scripts/jquery-ui-{version}.js",
                "~/Scripts/search.js",
                "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/comment-add-edit").Include(
                "~/Scripts/tinymce/tinymce-client-val.js",
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/category-add-edit").Include(
                "~/Scripts/validation-extensions.js",
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/register-user").Include(
                "~/Scripts/validation-extensions.js",
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/post-add-edit").Include(
                "~/Scripts/validation-extensions.js",
                "~/Scripts/tinymce/tinymce-client-val.js",
                "~/Scripts/jquery.validate*",
                "~/Scripts/fileinput.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/profile-settings").Include(
                "~/Scripts/validation-extensions.js",
                "~/Scripts/tinymce/tinymce-client-val.js",
                "~/Scripts/jquery.validate*",
                "~/Scripts/fileinput.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryAjax").Include(
                "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/gridmvc").Include(
                "~/Scripts/gridmvc.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/top").Include(
                 "~/Scripts/to-top.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));
        }
    }
}