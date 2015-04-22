namespace MagazineProject.Services.Common.Administaration.Admin
{
    using System.Linq;

    using MagazineProject.Data.Models;
    using MagazineProject.Web.Models.Area.Admin.InputViewModels.User;
    using MagazineProject.Web.Models.InputModels.Base.User;

    public interface IAdminUsersService
    {
        IQueryable<User> GetUsersForGrid();

        void Edit(User model, AdminUserEditViewModel viewModel);

        IQueryable<User> GetUserById(string userId);
    }
}
