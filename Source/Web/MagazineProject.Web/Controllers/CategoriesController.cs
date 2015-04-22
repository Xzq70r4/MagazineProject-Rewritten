namespace MagazineProject.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using MagazineProject.Services.Common;
    using MagazineProject.Web.Models.Categories;

    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categories;

        public CategoriesController(ICategoriesService categories)
        {
            this.categories = categories;
        }

        public ActionResult CategoryNavigation()
        {
            var categories = this.categories
                .GetCategories()
                .Project()
                .To<CategoryViewModel>()
                .ToList();

            return this.PartialView("_CategoryNavigationPartial", categories);
        }
    }
}