using System.Linq;
using MagazineProject.Data.Models;

namespace MagazineProject.Services.Common.Data
{
    public interface ICommentsService
    {
        void AddComment(string userId, int postId, string content);
        IQueryable<Comment> GetPostComments(int id);
    }
}