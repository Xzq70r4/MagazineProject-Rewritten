using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagazineProject.Data.Models;

namespace MagazineProject.Services.Common.Data
{
    public interface IPostsService
    {
        IQueryable<Post> Autocomplate(string term);

        IQueryable<Post> SearchPosts(string searchTerm);

        IQueryable<Post> GetPostById(int id);

        IQueryable<Post> GetPostsByCategoryId(int categoryId);

        IQueryable<Post> GetPostsWithVideo(int takeNumber);

        IQueryable<Post> GetNumberOfPosts(int takeNumber);

    }
}
