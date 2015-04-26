namespace MagazineProject.Services.Administration.Admin
{
    using System.Linq;

    using MagazineProject.Data.Models;
    using MagazineProject.Data.UnitOfWork;
    using MagazineProject.Services.Common.Administaration.Admin;
    using MagazineProject.Services.Common.Base;
    using MagazineProject.Web.Infrastructure.Sanitizer;
    using MagazineProject.Web.Models.Area.Admin.InputViewModels.User;

    public class AdminUsersService : BaseUsersService, IAdminUsersService
    {
        public AdminUsersService(IUnitOfWorkData data, ISanitizer sanitizer)
            : base(data, sanitizer)
        {
        }

        public IQueryable<User> GetUsersForGrid()
        {
            var users = this.Data
                .Users
                .All()
                .OrderByDescending(u => u.CreatedOn);

            return users;
        }

        public IQueryable<User> GetUserById(string userId)
        {
            return base.GetProfileById(userId);
        }

        public void Edit(User model, AdminUserEditViewModel viewModel)
        {
            base.Edit(model, viewModel);
        }
    }
}
