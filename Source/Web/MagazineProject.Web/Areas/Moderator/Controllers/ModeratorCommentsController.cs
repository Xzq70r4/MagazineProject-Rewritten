namespace MagazineProject.Web.Areas.Moderator.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using MagazineProject.Common;
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

                this.TempData["Message"] = string.Format(GlobalConstants.SuccessMessage, " Edited Comment.");

                return this.RedirectToAction("Index", "ModeratorComments", new { area = "Moderator" });
            }

            this.TempData["Message"] = string.Format(GlobalConstants.FailMessage, " Edited Comment.");

            return this.View(viewModel);
        }
    }
}