namespace MagazineProject.Web.Areas.Users.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using MagazineProject.Services.Common.User;
    using MagazineProject.Web.Controllers.Base;
    using MagazineProject.Web.Models.Area.Users.UserPosts;

    using Microsoft.AspNet.Identity;

    using PagedList;

    public class UserPostsController : BaseController
    {
        private readonly IProfilesService profiles;

        public UserPostsController(IProfilesService profiles)
        {
            this.profiles = profiles;
        }

        public ActionResult Index(int? page, string userName)
        {
            var posts = this.profiles
                .GetProfilePosts(userName)
                .Project()
                .To<UserPostViewModel>()
                .ToList();

            int pageSize = 12;
            int pageNumber = page ?? 1;

            // If the user tries to access a page that is less than 0.
            pageNumber = pageNumber < 0 ? 1 : pageNumber;

            return this.View("_PostsPartial", posts.ToPagedList(pageNumber, pageSize));
        }
    }
}