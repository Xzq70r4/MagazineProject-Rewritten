namespace MagazineProject.Web.Areas.Users.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using MagazineProject.Services.Common.User;
    using MagazineProject.Web.Controllers.Base;
    using MagazineProject.Web.Models.Area.Users.UserComments;

    using Microsoft.AspNet.Identity;

    using PagedList;

    public class UserCommentsController : BaseController
    {
        private readonly IProfilesService profiles;

        public UserCommentsController(IProfilesService profiles)
        {
            this.profiles = profiles;
        }

        public ActionResult Index(int? page, string id)
        {
            string userId;
            if (id == null)
            {
                userId = this.User.Identity.GetUserId();
            }
            else
            {
                userId = id;
            }

            var comments = this.profiles
                .GetProfileComments(userId)
                .Project()
                .To<UserCommentViewModel>()
                .ToList();

            int pageSize = 6;
            int pageNumber = page ?? 1;

            // If the user tries to access a page that is less than 0.
            pageNumber = pageNumber < 0 ? 1 : pageNumber;

            return this.View("_CommentPartial", comments.ToPagedList(pageNumber, pageSize));
        }
    }
}