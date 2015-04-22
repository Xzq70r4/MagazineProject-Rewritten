namespace MagazineProject.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;

    using MagazineProject.Common;
    using MagazineProject.Web.Controllers.Base;

    [Authorize(Roles = GlobalConstants.Admin)]
    public class AdminController : BaseController
    {
    }
}