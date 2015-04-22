namespace MagazineProject.Services.Common
{
    using System.Linq;

    using MagazineProject.Data.Models;

    public interface ICategoriesService
    {
        IQueryable<Category> GetCategories();
    }
}
