namespace MagazineProject.Web.Areas.Users.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using MagazineProject.Data.Models;
    using MagazineProject.Data.UnitOfWork;
    using MagazineProject.Services.Common.User;
    using MagazineProject.Web.Controllers.Base;
    using MagazineProject.Web.Infrastructure.Sanitizer;
    using MagazineProject.Web.Models.Area.Users.InputViewModels.Settings;

    using Microsoft.AspNet.Identity;

    [Authorize]
    public class SettingsController : BaseController
    {

        private readonly IProfilesService profiles;

        public SettingsController(IProfilesService profiles)
        {
            this.profiles = profiles;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();

            var user = this.profiles
                .GetProfileById(userId)
                .Project()
                .To<UserProfileSettingsViewModel>()
                .FirstOrDefault();

            return this.View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserProfileSettingsViewModel settings)
        {
            if (this.ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();
                var user = this.profiles
                    .GetProfileById(userId)
                    .FirstOrDefault();

                this.profiles.Edit(user, settings);

                TempData["Message"] = "<div class='alert alert-success'><a href='#' class='close' data-dismiss='alert'>&times;</a><strong>Success!</strong> Successfully Save.</div> ";

                return this.RedirectToAction("Index", new { controller = "Profile", area = "Users" });
            }

            TempData["Message"] = "<div class='alert alert-danger'><a href='#' class='close' data-dismiss='alert'>&times;</a><strong>Fail!</strong> Not Successfully Save.</div>";

            return this.View(settings);
        }
    }
}