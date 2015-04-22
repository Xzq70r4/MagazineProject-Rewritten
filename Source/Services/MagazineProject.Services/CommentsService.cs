namespace MagazineProject.Services
{
    using System.Linq;

    using MagazineProject.Data.Common.Model;
    using MagazineProject.Data.Models;
    using MagazineProject.Data.UnitOfWork;
    using MagazineProject.Services.Common;
    using MagazineProject.Services.Common.Base;
    using MagazineProject.Web.Infrastructure.Sanitizer;

    public class CommentsService : BaseService, ICommentsService
    {
     
        private readonly ISanitizer sanitizer;

        public CommentsService(IUnitOfWorkData data, ISanitizer sanitizer)
            : base(data)
        {
            this.sanitizer = sanitizer;
        }

        public void AddComment(string userId, int postId, string content)
        {
            var commet = new Comment
            {
                Content = this.sanitizer.Sanitize(content),
                PostId = postId,
                AuthorId = userId
            };

            this.Data.Comments.Add(commet);
            this.Data.SaveChanges();
        }

        public IQueryable<Comment> GetPostComments(int id)
        {
            var comments = this.Data
                .Comments
                .All()
                .Where(c => c.PostId == id &&
                            c.Status == Status.Published);

            return comments;
        }
    }
}