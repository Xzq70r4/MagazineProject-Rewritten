namespace MagazineProject.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using MagazineProject.Services.Common.Moderator;
    using MagazineProject.Web.Infrastructure.Populators;
    using MagazineProject.Web.Models.Area.Admin.InputViewModels.Post;
    using MagazineProject.Web.Models.Area.Grid;

    using Microsoft.AspNet.Identity;

    public class AdminPostsController : Controller
    {
        private readonly IDropDownListPopulator populator;
        private readonly IAdministrationPostsService adminPosts;


        public AdminPostsController(IDropDownListPopulator populator, IAdministrationPostsService adminPosts)
        {
            this.populator = populator;
            this.adminPosts = adminPosts;
        }

        public ActionResult Index()
        {
            var posts = this.adminPosts
                .GetPostsForGrid()
                .Project()
                .To<GridPostViewModel>();

            return this.View(posts);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var addPostViewModel = new AdminAddPostViewModel
            {
                Categories = this.populator.GetCategories()
            };

            return View(addPostViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AdminAddPostViewModel viewModel)
        {
            if (viewModel != null && ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();

                this.adminPosts.AddDbPost(viewModel, userId);

                TempData["Message"] = "<div class='alert alert-success'><a href='#' class='close' data-dismiss='alert'>&times;</a><strong>Success!</strong> Successfully Added Post.</div> ";

                return this.RedirectToAction("Index", "AdminPosts", new { area = "Admin" });
            }

            TempData["Message"] = "<div class='alert alert-danger'><a href='#' class='close' data-dismiss='alert'>&times;</a><strong>Fail!</strong> Not Successfully Added Post.</div>";

            viewModel.Categories = this.populator.GetCategories();

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var post = this.adminPosts
                .GetPostById(id)
                .FirstOrDefault();

            var editPostViewModel = new AdminEditPostViewModel
            {
                Title = post.Title,
                Content = post.Content,
                CategoryId = post.CategoryId,
                Categories = this.populator.GetCategories(),
                Status = post.Status
            };

            return View(editPostViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AdminEditPostViewModel viewModel)
        {
            if (viewModel != null && ModelState.IsValid)
            {
                var post = this.adminPosts
                    .GetPostById(id)
                    .FirstOrDefault();

                this.adminPosts.Edit(post, viewModel);

                TempData["Message"] = "<div class='alert alert-success'><a href='#' class='close' data-dismiss='alert'>&times;</a><strong>Success!</strong> Successfully Edited Post.</div> ";

                return this.RedirectToAction("Index", "AdminPosts", new { area = "Admin" });

            }

            TempData["Message"] = "<div class='alert alert-danger'><a href='#' class='close' data-dismiss='alert'>&times;</a><strong>Fail!</strong> Not Successfully Edited Post.</div>";

            viewModel.Categories = this.populator.GetCategories();

            return this.View(viewModel);
        }
    }
}