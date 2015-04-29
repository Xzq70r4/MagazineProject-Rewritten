namespace MagazineProject.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using MagazineProject.Common;
    using MagazineProject.Services.Common.Administaration.Admin;
    using MagazineProject.Web.Models.Area.Admin.InputViewModels.SiteConstant;
    using MagazineProject.Web.Models.Area.Grid;

    public class AdminSiteConstantsController : AdminController
    {
        private readonly IAdminSiteConstantsService siteConstants;

        public AdminSiteConstantsController(IAdminSiteConstantsService siteConstants)
        {
            this.siteConstants = siteConstants;
        }

        public ActionResult Index()
        {
            var siteConsts = this.siteConstants
                .GetSiteConstantsForGrid()
                .Project()
                .To<GridSiteConstantViewModel>();

            return View(siteConsts);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var constant = this.siteConstants
                .GetSiteConstantById(id)
                .FirstOrDefault();

            var editSiteConstantViewModel = new AdminEditSiteConstantViewModel
            {
                Value = constant.Value,
                Description = constant.Description
            };

            return View(editSiteConstantViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AdminEditSiteConstantViewModel viewModel)
        {
            if (viewModel != null && ModelState.IsValid)
            {
                var constant = this.siteConstants
                    .GetSiteConstantById(id)
                    .FirstOrDefault();

                this.siteConstants.Edit(viewModel, constant);
                this.TempData["Message"] = string.Format(GlobalConstants.SuccessMessage, " Edited Site Constant.");

                return this.RedirectToAction("Index", "AdminSiteConstants", new { area = "Admin" });
            }

            this.TempData["Message"] = string.Format(GlobalConstants.FailMessage, " Edited Site Constant.");

            return this.View(viewModel);
        }
    }
}