namespace MagazineProject.Services.Users
{
    using System.Linq;

    using MagazineProject.Data.Common.Model;
    using MagazineProject.Data.Models;
    using MagazineProject.Data.UnitOfWork;
    using MagazineProject.Services.Common.Base;
    using MagazineProject.Services.Common.User;
    using MagazineProject.Web.Infrastructure.Sanitizer;
    using MagazineProject.Web.Models.Area.Users.InputViewModels.Settings;

    public class ProfilesService : BaseUsersService, IProfilesService
    {
        public ProfilesService(IUnitOfWorkData data, ISanitizer sanitizer)
            : base(data, sanitizer)
        {
        }

        public IQueryable<User> GetProfileById(string userId)
        {
            return base.GetProfileById(userId);
        }

        public IQueryable<User> GetProfileByName(string userName)
        {
            var user = Data
                .Users
                .All()
                .Where(u => u.UserName == userName);

            return user;
        }

        public void Edit(User model, UserProfileSettingsViewModel viewModel)
        {
            base.Edit(model, viewModel);
        }

        public IQueryable<Comment> GetProfileComments(string userName)
        {
            var userComments = this.Data
                .Comments
                .All()
                .Where(c => c.Author.UserName == userName &&
                            c.Status == Status.Published);

            return userComments;
        }

        public IQueryable<Post> GetProfilePosts(string userName)
        {
            var userPosts = this.Data
                .Posts
                .All()
                .Where(p => p.Author.UserName == userName &&
                            p.Status == Status.Published);

            return userPosts;
        }
    }
}
