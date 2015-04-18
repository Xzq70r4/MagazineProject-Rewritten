namespace MagazineProject.Web.Areas.Moderator.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using MagazineProject.Services.Common.Moderator;
    using MagazineProject.Web.Models.Area.Grid;
    using MagazineProject.Web.Models.Area.Moderator.InputViewModels.Comment;

    public class ModeratorCommentsController : ModeratorController
    {
        private readonly IAdministrationCommentsService moderatorComments;

        public ModeratorCommentsController(IAdministrationCommentsService moderatorComments)
        {
            this.moderatorComments = moderatorComments;
        }
        public ActionResult Index()
        {
            var comments = moderatorComments
                .GetCommentsForGrid()
                .Project()
                .To<GridCommentViewModel>();

            return this.View(comments);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var comment = this.moderatorComments
                .GetCommentById(id)
                .FirstOrDefault();

            var editCommentViewModel = new ModeratorEditCommentViewModel
            {
                Content = comment.Content,
                Status = comment.Status
            };

            return this.View(editCommentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ModeratorEditCommentViewModel viewModel)
        {
            if (viewModel != null && ModelState.IsValid)
            {
                var comment = this.moderatorComments
               .GetCommentById(id)
               .FirstOrDefault();

                this.moderatorComments.Edit(comment, viewModel);

                TempData["Message"] = "<div class='alert alert-success'><a href='#' class='close' data-dismiss='alert'>&times;</a><strong>Success!</strong> Successfully Edited Comment.</div> ";

                return this.RedirectToAction("Index", "ModeratorComments", new { area = "Moderator" });
            }

            TempData["Message"] = "<div class='alert alert-danger'><a href='#' class='close' data-dismiss='alert'>&times;</a><strong>Fail!</strong> Not Successfully Edited Comment.</div>";

            return this.View(viewModel);
        }
    }
}