namespace MagazineProject.Services
{
    using System.Linq;

    using MagazineProject.Data.Models;
    using MagazineProject.Data.UnitOfWork;
    using MagazineProject.Services.Common;
    using MagazineProject.Services.Common.Data;

    /// <summary>
    ///     The categories service.
    /// </summary>
    public class CategoriesService : BaseService, ICategoriesService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoriesService"/> class.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        public CategoriesService(IUnitOfWorkData data)
            : base(data)
        {
        }

        /// <summary>
        /// The get categories.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<Category> GetCategories()
        {
            var categories = this.Data.Categories.All().OrderBy(c => c.Name);

            return categories;
        }
    }
}