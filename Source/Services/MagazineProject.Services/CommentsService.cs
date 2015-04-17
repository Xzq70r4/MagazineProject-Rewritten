namespace MagazineProject.Services
{
    using System.Linq;

    using MagazineProject.Data.Models;
    using MagazineProject.Data.UnitOfWork;
    using MagazineProject.Services.Common;
    using MagazineProject.Web.Infrastructure.Sanitizer;

    /// <summary>
    /// The comments service.
    /// </summary>
    public class CommentsService : BaseService, ICommentsService
    {
        /// <summary>
        /// The sanitizer.
        /// </summary>
        private readonly ISanitizer sanitizer;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentsService"/> class.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <param name="sanitize">
        /// The sanitize.
        /// </param>
        public CommentsService(IUnitOfWorkData data, ISanitizer sanitizer)
            : base(data)
        {
            this.sanitizer = sanitizer;
        }

        /// <summary>
        /// The add comment.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="postId">
        /// The post id.
        /// </param>
        /// <param name="content">
        /// The content.
        /// </param>
        public void AddComment(string userId, int postId, string content)
        {
            var commet = new Comment
            {
                Content = this.sanitizer.Sanitize(content),
                //Content = content,
                PostId = postId,
                AuthorId = userId
            };

            this.Data.Comments.Add(commet);
            this.Data.SaveChanges();
        }

        /// <summary>
        /// The get post comments.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<Comment> GetPostComments(int id)
        {
            var comments = this.Data
                .Comments
                .All()
                .Where(c => c.PostId == id);

            return comments;
        }
    }
}