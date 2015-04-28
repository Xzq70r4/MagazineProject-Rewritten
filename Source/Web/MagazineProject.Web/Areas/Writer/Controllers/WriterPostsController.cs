namespace MagazineProject.Web.Areas.Writer.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using MagazineProject.Common;
    using MagazineProject.Services.Common.Writer;
    using MagazineProject.Web.Infrastructure.Populators;
    using MagazineProject.Web.Models.Area.Grid;
    using MagazineProject.Web.Models.Area.Writer.InputViewModels;

    using Microsoft.AspNet.Identity;

    public class WriterPostsController : WriterController
    {
        private readonly IDropDownListPopulator populator;
        private readonly IWriterPostsService writerPosts;


        public WriterPostsController(IDropDownListPopulator populator, IWriterPostsService writerPosts)
        {
            this.populator = populator;
            this.writerPosts = writerPosts;
        }

        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();

            var posts = this.writerPosts
                .GetPostsForGrid(userId)
                .Project()
                .To<GridPostViewModel>()
                .ToList();

            return this.View(posts);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var addPostViewModel = new WriterAddPostViewModel
            {
                Categories = this.populator.GetCategories()
            };

            return View(addPostViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(WriterAddPostViewModel viewModel)
        {
            if (viewModel != null && ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();

                this.writerPosts.AddDbPost(viewModel, userId);

                this.TempData["Message"] = string.Format(GlobalConstants.SuccessMessage, " Added Post.");

                return this.RedirectToAction("Index", "WriterPosts", new { area = "Writer" });
            }

            this.TempData["Message"] = string.Format(GlobalConstants.FailMessage, " Added Post.");

            viewModel.Categories = this.populator.GetCategories();

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var userId = this.User.Identity.GetUserId();

            var post = this.writerPosts
                .GetPostById(id)
                .FirstOrDefault();

            if (userId == post.AuthorId)
            {
                var editPostViewModel = new WriterEditPostViewModel
                {
                    Title = post.Title,
                    Content = post.Content,
                    CategoryId = post.CategoryId,
                    UrlVideo = post.UrlVideo
                };

                ViewBag.SelectedItem = populator.GetSelectedCategories();

                return View(editPostViewModel);
            }

            this.TempData["Message"] = string.Format(GlobalConstants.FailMessage, "! This not your post!");

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WriterEditPostViewModel viewModel)
        {
            if (viewModel != null && ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();
                var post = this.writerPosts.GetPostById(id).FirstOrDefault();
                if (userId == post.AuthorId)
                {
                    this.writerPosts.Edit(post, viewModel);

                    this.TempData["Message"] = string.Format(GlobalConstants.SuccessMessage, " Edited Post.");

                    return this.RedirectToAction("Index", "WriterPosts", new { area = "Writer" });
                }

                this.TempData["Message"] = string.Format(GlobalConstants.FailMessage, "! This not your post!");

                return this.RedirectToAction("Index");
            }

            this.TempData["Message"] = string.Format(GlobalConstants.FailMessage, " Edited Post.");

            ViewBag.SelectedItem = populator.GetSelectedCategories();

            return this.View(viewModel);
        }
    }
}