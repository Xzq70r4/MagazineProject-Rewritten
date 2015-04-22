namespace MagazineProject.Services.Common.Administaration.Admin
{
    using System.Linq;

    using MagazineProject.Data.Models;
    using MagazineProject.Web.Models.InputModels.Base.Category;

    public interface IAdminCategoriesService
    {
        IQueryable<Category> GetCategoriesForGrid();

        IQueryable<Category> GetCategoryById(int categoryId);

        void AddDbCategory(BaseAdministrationCategoryViewModel viewModel);

        void Edit(BaseAdministrationCategoryViewModel viewModel, Category category);

        void Delete(int categoryId);
    }
}