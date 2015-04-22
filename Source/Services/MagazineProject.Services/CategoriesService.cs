namespace MagazineProject.Services
{
    using System.Linq;

    using MagazineProject.Data.Models;
    using MagazineProject.Data.UnitOfWork;
    using MagazineProject.Services.Common;
    using MagazineProject.Services.Common.Base;

    public class CategoriesService : BaseService, ICategoriesService
    {
        public CategoriesService(IUnitOfWorkData data)
            : base(data)
        {
        }

        public IQueryable<Category> GetCategories()
        {
            var categories = this.Data
                .Categories
                .All()
                .Where(c => c.IsHidden == false)
                .OrderBy(c => c.Name);

            return categories;
        }
    }
}