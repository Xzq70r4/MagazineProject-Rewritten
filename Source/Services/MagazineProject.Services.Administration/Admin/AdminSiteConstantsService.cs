namespace MagazineProject.Services.Administration.Admin
{
    using System.Linq;

    using MagazineProject.Data.Models;
    using MagazineProject.Data.UnitOfWork;
    using MagazineProject.Services.Common.Administaration.Admin;
    using MagazineProject.Services.Common.Base;
    using MagazineProject.Web.Models.Area.Admin.InputViewModels.SiteConstant;

    public class AdminSiteConstantsService : BaseService, IAdminSiteConstantsService
    {
        public AdminSiteConstantsService(IUnitOfWorkData data)
            : base(data)
        {
        }

        public IQueryable<SiteConstant> GetSiteConstantsForGrid()
        {
            var siteConst = this.Data
                .SiteConstants
                .All()
                .OrderByDescending(c => c.Description);

            return siteConst;
        }

        public IQueryable<SiteConstant> GetSiteConstantById(int constId)
        {
            var category = this.Data
                .SiteConstants
                .All()
                .Where(c => c.Id == constId);

            return category;
        }

        public void Edit(AdminEditSiteConstantViewModel viewModel, SiteConstant constant)
        {
            constant.Value = viewModel.Value;

            this.Data.SiteConstants.Update(constant);
            this.Data.SaveChanges();
        }
    }
}
