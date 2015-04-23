namespace MagazineProject.Services.Common.Administaration.Admin
{
    using System.Linq;

    using MagazineProject.Data.Models;
    using MagazineProject.Web.Models.Area.Admin.InputViewModels.SiteConstant;

    public interface IAdminSiteConstantsService
    {
        IQueryable<SiteConstant> GetSiteConstantsForGrid();

        IQueryable<SiteConstant> GetSiteConstantById(int constId);

        void Edit(AdminEditSiteConstantViewModel viewModel, SiteConstant constant);
    }
}
