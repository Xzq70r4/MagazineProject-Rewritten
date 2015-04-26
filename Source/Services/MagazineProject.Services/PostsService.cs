namespace MagazineProject.Services
{
    using System.Linq;

    using MagazineProject.Common;
    using MagazineProject.Data.Common.Model;
    using MagazineProject.Data.Models;
    using MagazineProject.Data.UnitOfWork;
    using MagazineProject.Services.Common;
    using MagazineProject.Services.Common.Base;

    public class PostsService : BaseService, IPostsService
    {
        public PostsService(IUnitOfWorkData data)
            : base(data)
        {
        }

        public IQueryable<Post> SearchPosts(string searchTerm)
        {
            var searchPosts =
                this.Data.Posts.All()
                    .Where(p => (searchTerm == null || p.Title.Contains(searchTerm)) &&
                                 p.Status == Status.Published &&
                                 p.Category.IsHidden == false)
                    .OrderByDescending(p => p.CreatedOn);

            return searchPosts;
        }

        public IQueryable<Post> Autocomplate(string term)
        {
            var model = this.Data
                .Posts
                .All()
                .Where(p => p.Title.Contains(term) &&
                            p.Status == Status.Published &&
                            p.Category.IsHidden == false)
                .Take(10);

            return model;
        }

        public IQueryable<Post> GetPostById(int id)
        {
            var post = this.Data
                .Posts
                .All()
                .Where(p => p.Id == id &&
                            p.Status == Status.Published &&
                            p.Category.IsHidden == false);

            return post;
        }

        public IQueryable<Post> GetPostsByCategoryId(int categoryId)
        {
            var post = this.Data
                .Posts.All()
                .Where(p => p.CategoryId == categoryId &&
                            p.Status == Status.Published &&
                            p.Category.IsHidden == false)
                .OrderByDescending(p => p.CreatedOn);

            return post;
        }

        public IQueryable<Post> GetPostsWithVideo()
        {
            var postVideo = Data
                .SiteConstants
                .All()
                .FirstOrDefault(p => p.Description ==
                    GlobalConstants.SiteConstVideoPost);

            var postWithVideo = this.Data
                .Posts
                .All()
                .Where(p => p.UrlVideo != null &&
                            p.Status == Status.Published &&
                            p.Category.IsHidden == false)
                .OrderByDescending(p => p.CreatedOn)
                .Take(postVideo.Value);

            return postWithVideo;
        }

        public IQueryable<Post> GetPostsForSlider()
        {
            var sliderConst = this.Data
                .SiteConstants
                .All()
                .FirstOrDefault(s => s.Description ==
                    GlobalConstants.SiteConstSlider);

            var posts = this.Data
                .Posts
                .All()
                .Where(p => p.Status == Status.Published &&
                            p.Category.IsHidden == false)
                .OrderByDescending(p => p.CreatedOn)
                .Take(sliderConst.Value);

            return posts;
        }
    }
}