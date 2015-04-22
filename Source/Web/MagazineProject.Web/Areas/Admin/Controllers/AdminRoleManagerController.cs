namespace MagazineProject.Web.Areas.Admin.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using MagazineProject.Common;
    using MagazineProject.Data;
    using MagazineProject.Data.Models;
    using MagazineProject.Services.Common.Administaration.Admin;
    using MagazineProject.Web.Infrastructure.Populators;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class AdminRoleManagerController : AdminController
    {
        //Source Code http://www.dotnetfunda.com/articles/show/2898/working-with-r

        private readonly IDropDownListPopulator populator;

        private readonly UserManager<User> userManager;

        public AdminRoleManagerController(IDropDownListPopulator populator, IAdminUsersService users, MagazineProjectDbContext context)
        {
            this.populator = populator;
            this.Context = context;
            this.userManager = new UserManager<User>(new UserStore<User>(this.Context));
        }

        private MagazineProjectDbContext Context { get; set; }

        public ActionResult Index()
        {
            var list = this.populator.GetRoles();

            this.ViewBag.Roles = list;

            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(string UserName, string RoleName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                var user = this.Context.Users.FirstOrDefault(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase));

                if (user == null)
                {
                    this.TempData["Message"] = string.Format(GlobalConstants.FailMessage, "! This User doesn't exist.");

                    return RedirectToAction("Index");
                }

                this.userManager.AddToRole(user.Id, RoleName);

                this.TempData["Message"] = string.Format(GlobalConstants.SuccessMessage, "Added User`s Role");

                return this.RedirectToAction("Index");
            }

            this.TempData["Message"] = string.Format(GlobalConstants.FailMessage, "! User name have white space or empty.");

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                var user = this.Context.Users.FirstOrDefault(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase));

                if (user == null)
                {
                    this.TempData["Message"] = string.Format(GlobalConstants.FailMessage, "! This User doesn't exist.");

                    return RedirectToAction("Index");
                }

                this.ViewBag.RolesForThisUser = this.userManager.GetRoles(user.Id);

                var list = this.populator.GetRoles();

                this.ViewBag.Roles = list;

                return this.View("Index");
            }

            this.TempData["Message"] = string.Format(GlobalConstants.FailMessage, "! User name have white space or empty.");

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleForUser(string UserName, string RoleName)
        {
            if (!string.IsNullOrWhiteSpace(UserName) &&
                !string.IsNullOrWhiteSpace(RoleName))
            {
                var user = this.Context.Users.FirstOrDefault(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase));

                if (user == null)
                {
                    this.TempData["Message"] = string.Format(GlobalConstants.FailMessage, "! This User doesn't exist.");
                    return this.RedirectToAction("Index");
                }
                if (this.userManager.IsInRole(user.Id, RoleName))
                {
                    this.userManager.RemoveFromRole(user.Id, RoleName);
                    this.TempData["Message"] = string.Format(GlobalConstants.SuccessMessage, "Deleted User Role");
                }
                else
                {
                    this.TempData["Message"] = string.Format(GlobalConstants.FailMessage, "! This user doesn't belong to selected role.");
                }

                return this.RedirectToAction("Index");
            }

            this.TempData["Message"] = string.Format(GlobalConstants.FailMessage, "! User not correct or Role not selected.");

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.userManager.Dispose();
                this.Context.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}