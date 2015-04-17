namespace MagazineProject.Web.Areas.Writer.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using MagazineProject.Services.Common.Writer;
    using MagazineProject.Web.Infrastructure.Populators;
    using MagazineProject.Web.Models.Area.Grid;
    using MagazineProject.Web.Models.Area.Writer.InputViewModels;
    using MagazineProject.Web.Models.Posts;

    using Microsoft.AspNet.Identity;

    public class WriterPostsController : WriterController
    {
        private IDropDownListPopulator populator;
        private readonly IWriterPostsService writerPosts;


        public WriterPostsController(IDropDownListPopulator populator, IWriterPostsService writerPosts)
        {
            this.populator = populator;
            this.writerPosts = writerPosts;
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

                TempData["Message"] = "<div class='alert alert-success'><a href='#' class='close' data-dismiss='alert'>&times;</a><strong>Success!</strong> Successfully Added Post.</div> ";

                return this.RedirectToAction("GetPostsForGrid", "WriterPosts", new { area = "Writer" });
            }

            TempData["Message"] = "<div class='alert alert-danger'><a href='#' class='close' data-dismiss='alert'>&times;</a><strong>Fail!</strong> Not Successfully Added Post.</div>";

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

            var editPostViewModel = new WriterEditPostViewModel
            {
                Title = post.Title,
                Content = post.Content,
                CategoryId = post.CategoryId,
                Categories = this.populator.GetCategories()
            };



            return View(editPostViewModel);
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
                }

                TempData["Message"] = "<div class='alert alert-success'><a href='#' class='close' data-dismiss='alert'>&times;</a><strong>Success!</strong> Successfully Edited Post.</div> ";

                return this.RedirectToAction("GetPostsForGrid", "WriterPosts", new { area = "Writer" });
            }

            TempData["Message"] = "<div class='alert alert-danger'><a href='#' class='close' data-dismiss='alert'>&times;</a><strong>Fail!</strong> Not Successfully Edited Post.</div>";

            viewModel.Categories = this.populator.GetCategories();

            return this.View(viewModel);
        }

        public ActionResult GetPostsForGrid()
        {
            var userId = this.User.Identity.GetUserId();

            var posts = this.writerPosts
                .GetPostsForGrid(userId)
                .Project()
                .To<GridPostViewModel>()
                .ToList();

            return this.View(posts);
        }
    }
}