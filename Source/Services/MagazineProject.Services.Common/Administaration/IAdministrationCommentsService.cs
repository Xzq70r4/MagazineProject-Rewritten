namespace MagazineProject.Services.Common.Moderator
{
    using System.Linq;

    using MagazineProject.Data.Models;
    using MagazineProject.Web.Models.InputModels.Base.Comment;

    public interface IAdministrationCommentsService
    {
        IQueryable<Comment> GetCommentsForGrid();

        IQueryable<Comment> GetCommentById(int commentId);

        void Edit(Comment comment, BaseAdministrationCommentsViewModel viewModel);
    }
}