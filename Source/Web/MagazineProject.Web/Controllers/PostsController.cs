namespace MagazineProject.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using MagazineProject.Services.Common.Data;
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

        public ActionResult Details(int id)
        {
            var post = this.posts
                .GetPostById(id)
                .Project()
                .To<PostDetailsViewModel>()
                .FirstOrDefault();

            return this.View(post);
        }

        public ActionResult GetPostsByCategory(int id, int? page)
        {
            var post = this.posts
                .GetPostsByCategoryId(id)
                .Project()
                .To<PostViewModel>()
                .ToList();

            this.ViewBag.CategoryId = id;

            int pageSize = 12;
            int pageNumber = page ?? 1;

            // If the user tries to access a page that is less than 0.
            pageNumber = pageNumber < 0 ? 1 : pageNumber;

            return this.Request.IsAjaxRequest()
                ? (ActionResult)this.PartialView("_PostsPartial", post.ToPagedList(pageNumber, pageSize)) 
                : this.View(post.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult GetFourPostsWithVideo()
        {
            var postWithVideo = this.posts
                .GetPostsWithVideo(4)
                .Project()
                .To<PostViewModel>()
                .ToList();

            return this.PartialView("_FourPostWithVideoPartial", postWithVideo);
        }

        public ActionResult GetFivePostForSlider()
        {
            var sliderPost = this.posts
                .GetNumberOfPosts(5)
                .Project()
                .To<PostViewModel>()
                .ToList();

            return this.PartialView("_SliderPostPartial", sliderPost);
        }
    }
}