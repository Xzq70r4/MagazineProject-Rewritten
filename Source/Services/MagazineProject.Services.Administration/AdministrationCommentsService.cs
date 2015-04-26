namespace MagazineProject.Services.Administration
{
    using System.Linq;

    using MagazineProject.Data.Models;
    using MagazineProject.Data.UnitOfWork;
    using MagazineProject.Services.Common.Base;
    using MagazineProject.Services.Common.Moderator;
    using MagazineProject.Web.Infrastructure.Sanitizer;
    using MagazineProject.Web.Models.InputModels.Base.Comment;

    //Common for Moderator and Admin Service
    public class AdministrationCommentsService : BaseService, IAdministrationCommentsService
    {
        private readonly ISanitizer sanitizer;

        public AdministrationCommentsService(IUnitOfWorkData data, ISanitizer sanitizer)
            : base(data)
        {
            this.sanitizer = sanitizer;
        }

        public IQueryable<Comment> GetCommentsForGrid()
        {
            var comments = this.Data
                .Comments
                .All()
                .Where(c => c.Post.Category.IsHidden == false)
                .OrderByDescending(p => p.CreatedOn);

            return comments;
        }

        public IQueryable<Comment> GetCommentById(int commentId)
        {
            var comment = this.Data
                .Comments
                .All()
                .Where(c => c.Id == commentId &&
                            c.Post.Category.IsHidden == false);

            return comment;
        }

        public void Edit(Comment comment, BaseAdministrationCommentsViewModel viewModel)
        {
            comment.Content = this.sanitizer.Sanitize(viewModel.Content);
            comment.Status = viewModel.Status;

            Data.Comments.Update(comment);
            Data.SaveChanges();
        }
    }
}
