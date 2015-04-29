namespace MagazineProject.Services.Common.User
{
    using System.Linq;

    using MagazineProject.Data.Models;
    using MagazineProject.Web.Models.Area.Users.InputViewModels.Settings;

    public interface IProfilesService
    {
        IQueryable<User> GetProfileById(string userId);

        IQueryable<User> GetProfileByName(string userName);

        void Edit(User model, UserProfileSettingsViewModel viewModel);

        IQueryable<Comment> GetProfileComments(string userName);

        IQueryable<Post> GetProfilePosts(string userName);
    }
}