namespace MagazineProject.Web.Areas.Users.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using MagazineProject.Services.Common.User;
    using MagazineProject.Web.Controllers.Base;
    using MagazineProject.Web.Models.Area.Users.UserProfiles;

    using Microsoft.AspNet.Identity;

    public class ProfileController : BaseController
    {
        private readonly IProfilesService users;

        public ProfileController(IProfilesService users)
        {
            this.users = users;
        }

        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            var currentUserId = this.User.Identity.GetUserId();

            var user = this.users
                .GetProfileById(currentUserId)
                .Project()
                .To<UserProfileViewModel>()
                .FirstOrDefault();

            return this.View(user);
        }

        [HttpGet]
        public ActionResult GetUserProfileById(string id)
        {
            var user = this.users
                .GetProfileById(id)
                .Project()
                .To<UserProfileViewModel>()
                .FirstOrDefault();

            return this.View(user);
        }
    }
}