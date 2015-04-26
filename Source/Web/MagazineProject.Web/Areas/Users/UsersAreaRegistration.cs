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
                name:"Users_default",
                url:"Users/{controller}/{action}/{id}",
                defaults:new
                    {
                        action = "Index", id = UrlParameter.Optional
                    });
        }
    }
}