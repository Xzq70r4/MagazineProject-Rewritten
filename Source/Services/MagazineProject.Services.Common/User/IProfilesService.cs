namespace MagazineProject.Services.Common.User
{
    using System.Linq;

    using MagazineProject.Data.Models;
    using MagazineProject.Web.Models.Area.Users.InputViewModels.Settings;

    public interface IProfilesService
    {
        IQueryable<User> GetProfileById(string userId);

        void UpdateProfile(User model, UserProfileSettingsViewModel viewModel);

        IQueryable<Comment> GetProfileComments(string userId);

        IQueryable<Post> GetProfilePosts(string userId);
    }
}