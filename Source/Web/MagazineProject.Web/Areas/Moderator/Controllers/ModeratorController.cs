namespace MagazineProject.Web.Areas.Moderator.Controllers
{
    using System.Web.Mvc;

    using MagazineProject.Common;
    using MagazineProject.Web.Controllers.Base;

    [Authorize(Roles = GlobalConstants.Moderator)]
    public class ModeratorController : BaseController
    {
    }
}