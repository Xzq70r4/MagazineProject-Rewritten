namespace MagazineProject.Services.Common
{
    using System.Linq;

    using MagazineProject.Data.Models;

    public interface ICommentsService
    {
        void AddComment(string userId, int postId, string content);

        IQueryable<Comment> GetPostComments(int id);
    }
}