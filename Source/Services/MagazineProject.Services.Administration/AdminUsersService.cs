namespace MagazineProject.Services.Administration
{
    using System.Linq;

    using MagazineProject.Data.Models;
    using MagazineProject.Data.UnitOfWork;
    using MagazineProject.Services.Common;
    using MagazineProject.Services.Common.Administaration;
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
            var users = Data
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
