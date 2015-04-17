namespace MagazineProject.Web.Areas.Writer.Controllers
{
    using System.Web.Mvc;

    using MagazineProject.Common;
    using MagazineProject.Web.Controllers.Base;

    [Authorize(Roles = GlobalConstants.Writer)]
    public class WriterController : BaseController
    {
    }
}