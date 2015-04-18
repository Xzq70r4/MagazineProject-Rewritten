namespace MagazineProject.Services.Administration
{
    using System;
    using System.Linq;

    using AutoMapper;

    using MagazineProject.Data.Models;
    using MagazineProject.Data.UnitOfWork;
    using MagazineProject.Services.Common;
    using MagazineProject.Services.Common.Moderator;
    using MagazineProject.Web.Models.InputModels.Base.Category;

    public class AdminCategoriesService : BaseService, IAdminCategoriesService
    {
        public AdminCategoriesService(IUnitOfWorkData data)
            : base(data)
        {
        }

        public IQueryable<Category> GetCategoriesForGrid()
        {
            var categories = this.Data
                .Categories
                .All()
                .OrderByDescending(c => c.Name);

            return categories;
        }

        public IQueryable<Category> GetCategoryById(int categoryId)
        {
            var category = this.Data
                .Categories
                .All()
                .Where(c => c.Id == categoryId);

            return category;
        }

        public void AddDbCategory(BaseAdministrationCategoryViewModel viewModel)
        {
            var dbCategory = Mapper.Map<Category>(viewModel);

            this.Data.Categories.Add(dbCategory);
            this.Data.SaveChanges();
        }

        public void Edit(BaseAdministrationCategoryViewModel viewModel, Category category)
        {
            category.Name = viewModel.Name;
            category.IsHidden = viewModel.IsHidden;

            this.Data.Categories.Update(category);
            this.Data.SaveChanges();
        }

        public void Delete(int categoryId)
        {
            var category = Data.Categories.GetById(categoryId);
            category.IsHidden = true;

            this.Data.Categories.Update(category);
            this.Data.SaveChanges();
        }
    }
}
