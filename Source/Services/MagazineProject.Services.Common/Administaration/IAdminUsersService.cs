using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineProject.Services.Common.Administaration
{
    using MagazineProject.Data.Models;
    using MagazineProject.Web.Models.Area.Admin.InputViewModels.User;
    using MagazineProject.Web.Models.Area.Users.InputViewModels.Settings;
    using MagazineProject.Web.Models.InputModels.Base.User;

    public interface IAdminUsersService
    {
        IQueryable<User> GetUsersForGrid();

        IQueryable<User> GetUserById(string userId);

        void Edit(User model, AdminUserEditViewModel viewModel);

        IQueryable<User> GetProfileById(string userId);

        void Edit(User model, BaseUserEditViewModel viewModel);
    }
}
