namespace MagazineProject.Services
{
    using System.Linq;

    using MagazineProject.Data.Common.Model;
    using MagazineProject.Data.Models;
    using MagazineProject.Data.UnitOfWork;
    using MagazineProject.Services.Common;
    using MagazineProject.Services.Common.Data;

    /// <summary>
    ///     The posts service.
    /// </summary>
    public class PostsService : BaseService, IPostsService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostsService"/> class.
        /// </summary>
        /// <param name="Data">
        /// The data.
        /// </param>
        public PostsService(IUnitOfWorkData Data)
            : base(Data)
        {
        }

        /// <summary>
        /// The search posts.
        /// </summary>
        /// <param name="searchTerm">
        /// The search term.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<Post> SearchPosts(string searchTerm)
        {
            var searchPosts =
                this.Data.Posts.All()
                    .Where(p => p.Status == Status.Published &&
                        (searchTerm == null || p.Title.Contains(searchTerm)))
                    .OrderByDescending(p => p.CreatedOn);

            return searchPosts;
        }

        /// <summary>
        /// The autocomplate.
        /// </summary>
        /// <param name="term">
        /// The term.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<Post> Autocomplate(string term)
        {
            var model = this.Data
                .Posts
                .All()
                .Where(p => p.Title.Contains(term) && p.Status == Status.Published)
                .Take(10);

            return model;
        }

        /// <summary>
        /// The get post by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<Post> GetPostById(int id)
        {
            var post = this.Data
                .Posts
                .All()
                .Where(p => p.Id == id && p.Status == Status.Published);

            return post;
        }

        /// <summary>
        /// The get posts by category id.
        /// </summary>
        /// <param name="categoryId">
        /// The category id.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<Post> GetPostsByCategoryId(int categoryId)
        {
            var post = this.Data
                .Posts
                .All()
                .Where(p => p.CategoryId == categoryId && p.Status == Status.Published)
                .OrderByDescending(p => p.CreatedOn);

            return post;
        }

        /// <summary>
        /// The get posts with video.
        /// </summary>
        /// <param name="takeNumber">
        /// The take number.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<Post> GetPostsWithVideo(int takeNumber)
        {
            // TODO: 4
            var postWithVideo = this.Data
                .Posts
                .All()
                .Where(p => p.UrlVideo != null)
                .OrderByDescending(p => p.CreatedOn)
                .Take(takeNumber);

            return postWithVideo;
        }

        // TODO: Check this
        /// <summary>
        /// The get number of posts.
        /// </summary>
        /// <param name="takeNumber">
        /// The take number.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<Post> GetNumberOfPosts(int takeNumber)
        {
            var posts = this.Data
                .Posts
                .All()
                .OrderByDescending(p => p.CreatedOn)
                .Take(takeNumber);

            return posts;
        }
    }
}