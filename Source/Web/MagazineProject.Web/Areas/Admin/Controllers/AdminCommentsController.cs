namespace MagazineProject.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using MagazineProject.Services.Common.Moderator;
    using MagazineProject.Web.Models.Area.Admin.InputViewModels.Comment;
    using MagazineProject.Web.Models.Area.Grid;
    using MagazineProject.Web.Models.Area.Moderator.InputViewModels.Comment;

    public class AdminCommentsController : Controller
    {
       private readonly IAdministrationCommentsService adminComments;

        public AdminCommentsController(IAdministrationCommentsService adminComments)
        {
            this.adminComments = adminComments;
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var comment = this.adminComments
                .GetCommentById(id)
                .FirstOrDefault();

            var editCommentViewModel = new AdminEditCommentViewModel
            {
                Content = comment.Content,
                Status = comment.Status
            };

            return this.View(editCommentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AdminEditCommentViewModel viewModel)
        {
            if (viewModel != null && ModelState.IsValid)
            {
                var comment = this.adminComments
               .GetCommentById(id)
               .FirstOrDefault();

                this.adminComments.Edit(comment, viewModel);

                TempData["Message"] = "<div class='alert alert-success'><a href='#' class='close' data-dismiss='alert'>&times;</a><strong>Success!</strong> Successfully Edited Comment.</div> ";

                return this.RedirectToAction("GetCommentsForGrid", "AdminComments", new { area = "Admin" });
            }

            TempData["Message"] = "<div class='alert alert-danger'><a href='#' class='close' data-dismiss='alert'>&times;</a><strong>Fail!</strong> Not Successfully Edited Comment.</div>";

            return this.View(viewModel);
        }

        public ActionResult GetCommentsForGrid()
        {
            var comments = adminComments
                .GetCommentsForGrid()
                .Project()
                .To<GridCommentViewModel>();

            return this.View(comments);
        }
    }
}