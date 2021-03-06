﻿namespace MagazineProject.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using MagazineProject.Common;
    using MagazineProject.Services.Common.Administaration.Admin;
    using MagazineProject.Web.Infrastructure.Caching;
    using MagazineProject.Web.Models.Area.Admin.InputViewModels.Category;
    using MagazineProject.Web.Models.Area.Grid;

    public class AdminCategoriesController : AdminController
    {
        private readonly IAdminCategoriesService categories;
        private readonly ICacheService cache;

        public AdminCategoriesController(IAdminCategoriesService categories, ICacheService cache)
        {
            this.categories = categories;
            this.cache = cache;
        }

        public ActionResult Index()
        {
            var categories = this.categories
                .GetCategoriesForGrid()
                .Project()
                .To<GridCategoryViewModel>();

            return this.View(categories);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var addCategoryViewMModel = new AdminAddCategoryViewModel();

            return this.View(addCategoryViewMModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AdminAddCategoryViewModel viewModel)
        {
            if (viewModel != null && ModelState.IsValid)
            {
                this.categories.AddDbCategory(viewModel);
                this.TempData["Message"] = string.Format(GlobalConstants.SuccessMessage, " Added Category.");
                this.ClearCategoryCache();

                return this.RedirectToAction("Index", "AdminCategories", new { area = "Admin" });
            }

            this.TempData["Message"] = string.Format(GlobalConstants.FailMessage, " Added Category.");

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = this.categories
                .GetCategoryById(id)
                .FirstOrDefault();

            var editPostViewModel = new AdminEditCategoryViewModel
            {
                Name = category.Name,
                IsHidden = category.IsHidden
            };

            return View(editPostViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AdminEditCategoryViewModel viewModel)
        {
            if (viewModel != null && ModelState.IsValid)
            {
                var category = this.categories
                    .GetCategoryById(id)
                    .FirstOrDefault();

                this.categories.Edit(viewModel, category);
                this.TempData["Message"] = string.Format(GlobalConstants.SuccessMessage, " Edited Category.");
                this.ClearCategoryCache();

                return this.RedirectToAction("Index", "AdminCategories", new { area = "Admin" });
            }

            this.TempData["Message"] = string.Format(GlobalConstants.FailMessage, " Edited Category.");

            return this.View(viewModel);
        }

        public ActionResult Delete(int id)
        {
            this.categories.Delete(id);
            this.ClearCategoryCache();

            return this.RedirectToAction("Index");
        }

        private void ClearCategoryCache()
        {
            this.cache.Clear("Categories");
        }
    }
}