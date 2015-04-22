namespace MagazineProject.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using MagazineProject.Services.Common;
    using MagazineProject.Web.Controllers.Base;
    using MagazineProject.Web.Models.Home;

    using PagedList;

    public class HomeController : BaseController
    {
        private readonly IPostsService posts;

        public HomeController(IPostsService posts)
        {
            this.posts = posts;
        }

        public ActionResult Autocomplete(string term)
        {
            var model = this.posts
                .Autocomplate(term)
                    .Select(p => new
                    {
                        label = p.Title.Substring(0, 125)
                    })
                    .ToList();

            return this.Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index(int? page, string searchTerm = null)
        {
            // TODO: Serch Contain Word
            var allPost = this.posts
                .SearchPosts(searchTerm)
                .Project()
                .To<PostViewModel>()
                .ToList();

            int pageSize = 6;
            int pageNumber = page ?? 1;

            // If the user tries to access a page that is less than 0.
            pageNumber = pageNumber < 0 ? 1 : pageNumber;

            if (Request.IsAjaxRequest())
            {
                return this.PartialView("_PostsPartial", allPost.ToPagedList(pageNumber, pageSize));
            }

            return this.View(allPost.ToPagedList(pageNumber, pageSize));
        }
    }
}