using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineProject.Services.Users
{
    using System.Web.Helpers;

    using MagazineProject.Data.Models;
    using MagazineProject.Data.UnitOfWork;
    using MagazineProject.Services.Common;
    using MagazineProject.Services.Common.User;
    using MagazineProject.Web.Infrastructure.Sanitizer;
    using MagazineProject.Web.Models.Area.Users.InputViewModels.Settings;

    public class ProfilesService : BaseService, IProfilesService
    {
        private readonly ISanitizer sanitizer;

        public ProfilesService(IUnitOfWorkData data, ISanitizer sanitize)
            : base(data)
        {
            this.sanitizer = sanitizer;
        }

        public IQueryable<User> GetProfileById(string userId)
        {
            return this.Data
                .Users
                .All()
                .Where(u => u.Id == userId);
        }

        public void UpdateProfile(User model, UserProfileSettingsViewModel viewModel)
        {
            model.InfoContent = viewModel.InfoContent == null ?
               viewModel.InfoContent : this.sanitizer.Sanitize(viewModel.InfoContent);
            model.Email = viewModel.Email;
            model.FirstName = viewModel.FirstName;
            model.LastName = viewModel.LastName;
            this.UpdateUserImage(model);

            this.Data.SaveChanges();
        }

        public IQueryable<Comment> GetProfileComments(string userId)
        {
            var userComments = this.Data
                .Comments
                .All()
                .Where(c => c.AuthorId == userId);

            return userComments;
        }

        public IQueryable<Post> GetProfilePosts(string userId)
        {
            var userPosts = this.Data
                .Posts
                .All()
                .Where(p => p.AuthorId == userId);

            return userPosts;
        }

        private void UpdateUserImage(User model)
        {
            var photo = WebImage.GetImageFromRequest();
            if (photo != null)
            {
                photo.Resize(width: 300, height: 200, preserveAspectRatio: false, preventEnlarge: false);
                byte[] data = photo.GetBytes();

                model.UserImage.Content = data;
                model.UserImage.FileExtension = photo.ImageFormat;
            }
        }
    }
}
