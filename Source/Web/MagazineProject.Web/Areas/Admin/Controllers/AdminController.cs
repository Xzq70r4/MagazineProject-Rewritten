using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazineProject.Web.Areas.Admin.Controllers
{
    using MagazineProject.Common;
    using MagazineProject.Web.Controllers.Base;

    [Authorize(Roles = GlobalConstants.Admin)]
    public class AdminController : BaseController
    {
    }
}