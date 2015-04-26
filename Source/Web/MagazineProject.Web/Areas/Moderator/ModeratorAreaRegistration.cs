namespace MagazineProject.Web.Areas.Moderator
{
    using System.Web.Mvc;

    public class ModeratorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Moderator";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name:"Moderator_default",
                url:"Moderator/{controller}/{action}/{id}",
                defaults:new
                    {
                        action = "Index", id = UrlParameter.Optional
                    });
        }
    }
}