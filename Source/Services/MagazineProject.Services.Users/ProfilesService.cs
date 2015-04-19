namespace MagazineProject.Services.Users
{
    using System.Linq;
    using System.Web.Helpers;

    using MagazineProject.Data.Common.Model;
    using MagazineProject.Data.Models;
    using MagazineProject.Data.UnitOfWork;
    using MagazineProject.Services.Common;
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

        public void Edit(User model, UserProfileSettingsViewModel viewModel)
        {
            base.Edit(model, viewModel);
        }

        public IQueryable<Comment> GetProfileComments(string userId)
        {
            var userComments = this.Data
                .Comments
                .All()
                .Where(c => c.AuthorId == userId &&
                            c.Status == Status.Published);

            return userComments;
        }

        public IQueryable<Post> GetProfilePosts(string userId)
        {
            var userPosts = this.Data
                .Posts
                .All()
                .Where(p => p.AuthorId == userId &&
                            p.Status == Status.Published);

            return userPosts;
        }
    }
}
