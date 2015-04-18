namespace MagazineProject.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using MagazineProject.Services.Common.Moderator;
    using MagazineProject.Web.Models.Area.Admin.InputViewModels.Category;
    using MagazineProject.Web.Models.Area.Grid;

    public class AdminCategoriesController : Controller
    {
        private readonly IAdminCategoriesService categories;

        public AdminCategoriesController(IAdminCategoriesService categories)
        {
            this.categories = categories;
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
            var addCategoryViewMModel = new AdminCategoryAddViewModel();

            return this.View(addCategoryViewMModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AdminCategoryAddViewModel viewModel)
        {
            if (viewModel != null && ModelState.IsValid)
            {

                this.categories.AddDbCategory(viewModel);

                TempData["Message"] = "<div class='alert alert-success'><a href='#' class='close' data-dismiss='alert'>&times;</a><strong>Success!</strong> Successfully Added Categories.</div> ";

                return this.RedirectToAction("Index", "AdminCategories", new { area = "Admin" });
            }

            TempData["Message"] = "<div class='alert alert-danger'><a href='#' class='close' data-dismiss='alert'>&times;</a><strong>Fail!</strong> Not Successfully Added Post.</div>";

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = this.categories
                .GetCategoryById(id)
                .FirstOrDefault();

            var editPostViewModel = new AdminCategoryEditViewModel
            {
                Name = category.Name,
                IsHidden = category.IsHidden
            };

            return View(editPostViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AdminCategoryEditViewModel viewModel)
        {
            if (viewModel != null && ModelState.IsValid)
            {
                var category = this.categories
                    .GetCategoryById(id)
                    .FirstOrDefault();

                this.categories.Edit(viewModel, category);

                TempData["Message"] = "<div class='alert alert-success'><a href='#' class='close' data-dismiss='alert'>&times;</a><strong>Success!</strong> Successfully Edited Category.</div> ";

                return this.RedirectToAction("Index", "AdminCategories", new { area = "Admin" });

            }

            TempData["Message"] = "<div class='alert alert-danger'><a href='#' class='close' data-dismiss='alert'>&times;</a><strong>Fail!</strong> Not Successfully Edited Category.</div>";

            return this.View(viewModel);
        }

        public ActionResult Delete(int id)
        {
            categories.Delete(id);

            return this.RedirectToAction("Index");
        }
    }
}