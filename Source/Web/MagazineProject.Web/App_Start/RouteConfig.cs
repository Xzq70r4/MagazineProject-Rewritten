namespace MagazineProject.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "AddComment",
            url: "Comments/{action}/{id}/{postTitle}",
            defaults: new
            {
                controller = "Comments",
                action = "Add",
            });

            routes.MapRoute(
            name: "PostDetails",
            url: "Posts/{id}/{postTitle}",
            defaults: new
            {
                controller = "Posts",
                action = "Details",
            });


            routes.MapRoute(
            name: "Categories",
            url: "{categoryName}",
            defaults: new
            {
                controller = "Posts",
                action = "PostsByCategory",
            });

            routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new
            {
                controller = "Home",
                action = "Index",
                id = UrlParameter.Optional
            });
        }
    }
}