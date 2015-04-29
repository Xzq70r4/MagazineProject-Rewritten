namespace MagazineProject.Web.Areas.Users
{
    using System.Web.Mvc;

    public class UsersAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Users";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
               name: "ProfilePostsVisit",
               url: "Users/Profile/{userName}-Posts",
               defaults: new
               {
                   controller = "UserPosts",
                   action = "Index"
               });

            context.MapRoute(
               name: "ProfileCommentsVisit",
               url: "Users/Profile/{userName}-Comments",
               defaults: new
               {
                   controller = "UserComments",
                   action = "Index"
               });

            context.MapRoute(
                name: "ProfileVisit",
                url: "Users/Profile/{userName}",
                defaults: new
                {
                    controller = "Profile",
                    action = "GetUserProfileByName"
                });

            context.MapRoute(
                name:"Users_default",
                url:"Users/{controller}/{action}/{id}",
                defaults:new
                    {
                        action = "Index",
                        id = UrlParameter.Optional
                    });
        }
    }
}