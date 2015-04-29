namespace MagazineProject.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using MagazineProject.Common;
    using MagazineProject.Services.Common;
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
        public ActionResult Add(int? id, string postTitle)
        {
            if (id == null || (postTitle == String.Empty))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = new AddCommentViewModel
            {
                PostId = id.Value
            };

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Add(AddCommentViewModel input, int? id, string postTitle)
        {
            if (id == null || (postTitle == String.Empty))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (this.ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();

                this.comments.AddComment(userId, id.Value, input.Content);


                this.TempData["Message"] = string.Format(GlobalConstants.SuccessMessage, " Added Comment.");

                return this.RedirectToAction("Details", "Posts", new { area = string.Empty, id = id, postTitle = postTitle.Replace(" ", "-")});
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