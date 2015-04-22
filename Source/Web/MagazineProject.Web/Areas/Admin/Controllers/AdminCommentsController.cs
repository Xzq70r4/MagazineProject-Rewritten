namespace MagazineProject.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using MagazineProject.Common;
    using MagazineProject.Services.Common.Moderator;
    using MagazineProject.Web.Models.Area.Admin.InputViewModels.Comment;
    using MagazineProject.Web.Models.Area.Grid;

    public class AdminCommentsController : AdminController
    {
       private readonly IAdministrationCommentsService adminComments;

        public AdminCommentsController(IAdministrationCommentsService adminComments)
        {
            this.adminComments = adminComments;
        }
        public ActionResult Index()
        {
            var comments = this.adminComments
                .GetCommentsForGrid()
                .Project()
                .To<GridCommentViewModel>();

            return this.View(comments);
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

                this.TempData["Message"] = string.Format(GlobalConstants.SuccessMessage, " Edited Comment.");


                return this.RedirectToAction("Index", "AdminComments", new { area = "Admin" });
            }

            this.TempData["Message"] = string.Format(GlobalConstants.FailMessage, " Edited Comment.");


            return this.View(viewModel);
        }
    }
}