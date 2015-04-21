namespace MagazineProject.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using MagazineProject.Common;
    using MagazineProject.Services.Common;
    using MagazineProject.Services.Common.Data;
    using MagazineProject.Web.Controllers.Base;
    using MagazineProject.Web.Models.Comments;
    using MagazineProject.Web.Models.InputModels.Comments;

    using Microsoft.AspNet.Identity;

    using PagedList;

    public class CommentsController : BaseController
    {
        private readonly ICommentsService comments;

        public CommentsController(ICommentsService comments)
        {
            this.comments = comments;
        }

        [HttpGet]
        public ActionResult AddComment(int id)
        {
            var model = new AddCommentViewModel
            {
                PostId = id
            };

            return this.View(model);
        }

        [HttpPost]
        public ActionResult AddComment(AddCommentViewModel input, int id)
        {
            if (this.ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();

                this.comments.AddComment(userId, id, input.Content);


                this.TempData["Message"] = string.Format(GlobalConstants.SuccessMessage, " Added Comment.");

                return this.RedirectToAction("Details", "Posts", new { id = id});
            }

            this.TempData["Message"] = string.Format(GlobalConstants.FailMessage, " Added Comment.");

            return this.View(input);
        }

        public ActionResult GetPostComments(int id, int? page)
        {
            var comments = this.comments
                .GetPostComments(id)
                .Project()
                .To<CommentViewModel>()
                .ToList();

             int pageSize = 6;
             int pageNumber = page ?? 1;

            // If the user tries to access a page that is less than 0.
            pageNumber = pageNumber < 0 ? 1 : pageNumber;

            return this.PartialView("_CommentPartial", comments.ToPagedList(pageNumber, pageSize));
        }
    }
}