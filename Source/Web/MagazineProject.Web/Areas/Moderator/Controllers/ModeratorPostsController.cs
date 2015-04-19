namespace MagazineProject.Web.Areas.Moderator.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using MagazineProject.Services.Common.Moderator;
    using MagazineProject.Web.Infrastructure.Populators;
    using MagazineProject.Web.Models.Area.Grid;
    using MagazineProject.Web.Models.Area.Moderator.InputViewModels.Post;

    using Microsoft.AspNet.Identity;

    public class ModeratorPostsController : ModeratorController
    {
        private IDropDownListPopulator populator;
        private readonly IAdministrationPostsService moderatorPosts;


        public ModeratorPostsController(IDropDownListPopulator populator, IAdministrationPostsService moderatorPosts)
        {
            this.populator = populator;
            this.moderatorPosts = moderatorPosts;
        }
        public ActionResult Index()
        {
            var posts = moderatorPosts
                .GetPostsForGrid()
                .Project()
                .To<GridPostViewModel>();

            return this.View(posts);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var addPostViewModel = new ModeratorAddPostViewModel
            {
                Categories = this.populator.GetCategories()
            };

            return View(addPostViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ModeratorAddPostViewModel viewModel)
        {
            if (viewModel != null && ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();

                this.moderatorPosts.AddDbPost(viewModel, userId);

                TempData["Message"] = "<div class='alert alert-success'><a href='#' class='close' data-dismiss='alert'>&times;</a><strong>Success!</strong> Successfully Added Post.</div> ";

                return this.RedirectToAction("Index", "ModeratorPosts", new { area = "Moderator" });
            }

            TempData["Message"] = "<div class='alert alert-danger'><a href='#' class='close' data-dismiss='alert'>&times;</a><strong>Fail!</strong> Not Successfully Added Post.</div>";

            viewModel.Categories = this.populator.GetCategories();

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var post = this.moderatorPosts
                .GetPostById(id)
                .FirstOrDefault();

            var editPostViewModel = new ModeratorEditPostViewModel
            {
                Title = post.Title,
                Content = post.Content,
                CategoryId = post.CategoryId,
                Categories = this.populator.GetCategories(),
                Status = post.Status,
                UrlVideo = post.UrlVideo
            };

            return View(editPostViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ModeratorEditPostViewModel viewModel)
        {
            if (viewModel != null && ModelState.IsValid)
            {
                var post = this.moderatorPosts
                    .GetPostById(id)
                    .FirstOrDefault();

                this.moderatorPosts.Edit(post, viewModel);

                TempData["Message"] = "<div class='alert alert-success'><a href='#' class='close' data-dismiss='alert'>&times;</a><strong>Success!</strong> Successfully Edited Post.</div> ";

                return this.RedirectToAction("Index", "ModeratorPosts", new { area = "Moderator" });
            }

            TempData["Message"] = "<div class='alert alert-danger'><a href='#' class='close' data-dismiss='alert'>&times;</a><strong>Fail!</strong> Not Successfully Edited Post.</div>";

            viewModel.Categories = this.populator.GetCategories();

            return this.View(viewModel);
        }
    }
}