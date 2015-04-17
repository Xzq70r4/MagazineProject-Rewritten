namespace MagazineProject.Services.Common.Data
{
    using System.Linq;

    using MagazineProject.Data.Models;

    public interface ICategoriesService
    {
        IQueryable<Category> GetCategories();
    }
}
