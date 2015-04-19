namespace MagazineProject.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using MagazineProject.Services.Common.Administaration;
    using MagazineProject.Web.Controllers.Base;
    using MagazineProject.Web.Models.Area.Admin.InputViewModels.User;
    using MagazineProject.Web.Models.Area.Grid;

    public class AdminUserController : BaseController
    {
        private readonly IAdminUsersService users;

        public AdminUserController(IAdminUsersService users)
        {
            this.users = users;
        }

        public ActionResult Index()
        {
            var users = this.users
                .GetUsersForGrid()
                .Project()
                .To<GridUserViewModel>();

            return View(users);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var user = this.users
                .GetProfileById(id)
                .Project()
                .To<AdminUserEditViewModel>()
                .FirstOrDefault();

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AdminUserEditViewModel settings, string id)
        {
            if (this.ModelState.IsValid)
            {
                var user = this.users
                    .GetProfileById(id)
                    .FirstOrDefault();

                this.users.Edit(user, settings);

                TempData["Message"] = "<div class='alert alert-success'><a href='#' class='close' data-dismiss='alert'>&times;</a><strong>Success!</strong> Successfully Save.</div> ";

                return this.RedirectToAction("Index", new { controller = "AdminUser", area = "Admin" });
            }

            TempData["Message"] = "<div class='alert alert-danger'><a href='#' class='close' data-dismiss='alert'>&times;</a><strong>Fail!</strong> Not Successfully Save.</div>";

            return this.View(settings);
        }
    }
}