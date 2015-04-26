using System.Web.Mvc;

namespace MagazineProject.Web.Areas.Writer
{
    public class WriterAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Writer";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name:"Writer_default",
                url:"Writer/{controller}/{action}/{id}",
                defaults:new
                    {
                        action = "Index", id = UrlParameter.Optional
                    });
        }
    }
}