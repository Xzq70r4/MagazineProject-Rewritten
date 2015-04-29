namespace MagazineProject.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using MagazineProject.Services.Common;
    using MagazineProject.Web.Controllers.Base;
    using MagazineProject.Web.Models.Home;
    using MagazineProject.Web.Models.Posts;

    using PagedList;

    public class PostsController : BaseController
    {
        private readonly IPostsService posts;

        public PostsController(IPostsService posts)
        {
            this.posts = posts;
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var post = this.posts
                .GetPostById(id.Value)
                .Project()
                .To<PostDetailsViewModel>()
                .FirstOrDefault();

            return this.View(post);
        }

        [HttpGet]
        public ActionResult PostsByCategory(string categoryName, int? page)
        {
            if (categoryName == String.Empty)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var post = this.posts
                .GetPostsByCategoryName(categoryName)
                .Project()
                .To<PostViewModel>()
                .ToList();

            //this.ViewBag.CategoryId = id;

            int pageSize = 12;
            int pageNumber = page ?? 1;

            // If the user tries to access a page that is less than 0.
            pageNumber = pageNumber < 0 ? 1 : pageNumber;

            return this.Request.IsAjaxRequest()
                ? (ActionResult)this.PartialView("_PostsPartial", post.ToPagedList(pageNumber, pageSize))
                : this.View(post.ToPagedList(pageNumber, pageSize));
        }

        [OutputCache(Duration = 60 * 60, VaryByParam = "none")]
        [ChildActionOnly]
        public ActionResult GetPostsWithVideo()
        {
            var postWithVideo = this.posts
                .GetPostsWithVideo()
                .Project()
                .To<PostViewModel>()
                .ToList();

            return this.PartialView("_FourPostWithVideoPartial", postWithVideo);
        }

        [OutputCache(Duration = 60 * 60, VaryByParam = "none")]
        [ChildActionOnly]
        public ActionResult GetPostsForSlider()
        {
            var sliderPost = this.posts
                .GetPostsForSlider()
                .Project()
                .To<PostViewModel>()
                .ToList();

            return this.PartialView("_SliderPostPartial", sliderPost);
        }
    }
}