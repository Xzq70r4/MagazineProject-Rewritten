namespace MagazineProject.Services.Common.Writer
{
    using System.Linq;

    using MagazineProject.Data.Models;
    using MagazineProject.Web.Models.Area.Writer.InputViewModels;

    public interface IWriterPostsService
    {
        IQueryable<Post> GetPostsForGrid(string userId);

        IQueryable<Post> GetPostById(int postId);

        void AddDbPost(WriterAddPostViewModel viewModel, string userId);

        void Edit(Post post, WriterEditPostViewModel viewModel);
    }
}