namespace MagazineProject.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using MagazineProject.Common;
    using MagazineProject.Services.Common.Administaration.Admin;
    using MagazineProject.Web.Infrastructure.Populators;
    using MagazineProject.Web.Models.Area.Admin.InputViewModels.User;
    using MagazineProject.Web.Models.Area.Grid;

    public class AdminUserController : AdminController
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
                .GetUserById(id)
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
                    .GetUserById(id)
                    .FirstOrDefault();

                this.users.Edit(user, settings);

                this.TempData["Message"] = string.Format(GlobalConstants.SuccessMessage, " Save.");

                return this.RedirectToAction("Index", new { controller = "AdminUser", area = "Admin" });
            }

            this.TempData["Message"] = string.Format(GlobalConstants.FailMessage, " Save.");

            return this.View(settings);
        }
    }
}