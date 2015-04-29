namespace MagazineProject.Services.Common
{
    using System.Linq;

    using MagazineProject.Data.Models;

    public interface IPostsService
    {
        IQueryable<Post> Autocomplate(string term);

        IQueryable<Post> SearchPosts(string searchTerm);

        IQueryable<Post> GetPostById(int id);

        IQueryable<Post> GetPostsByCategoryName(string categoryName);

        IQueryable<Post> GetPostsWithVideo();

        IQueryable<Post> GetPostsForSlider();
    }
}
