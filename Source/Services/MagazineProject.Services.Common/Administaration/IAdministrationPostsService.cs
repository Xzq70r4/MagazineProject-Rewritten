namespace MagazineProject.Services.Common.Moderator
{
    using System.Linq;

    using MagazineProject.Data.Models;
    using MagazineProject.Web.Models.InputModels.Base.Post;

    public interface IAdministrationPostsService
    {
        IQueryable<Post> GetPostsForGrid();

        IQueryable<Post> GetPostById(int postId);

        void AddDbPost(BaseAdministrationPostsViewModels viewModel, string userId);

        void Edit(Post post, BaseAdministrationPostsViewModels viewModel);
    }
}