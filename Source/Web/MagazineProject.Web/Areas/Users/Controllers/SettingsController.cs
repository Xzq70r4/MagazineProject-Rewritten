namespace MagazineProject.Web.Areas.Users.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using MagazineProject.Common;
    using MagazineProject.Services.Common.User;
    using MagazineProject.Web.Controllers.Base;
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

                this.TempData["Message"] = string.Format(GlobalConstants.SuccessMessage, " Save.");

                return this.RedirectToAction("Index", new { controller = "Profile", area = "Users" });
            }

            this.TempData["Message"] = string.Format(GlobalConstants.FailMessage, " Save.");

            return this.View(settings);
        }
    }
}