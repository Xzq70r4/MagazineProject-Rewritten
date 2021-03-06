﻿namespace MagazineProject.Services.Common.Base
{
    using System.Linq;
    using System.Web.Helpers;

    using MagazineProject.Common;
    using MagazineProject.Data.Models;
    using MagazineProject.Data.UnitOfWork;
    using MagazineProject.Web.Infrastructure.Sanitizer;
    using MagazineProject.Web.Models.InputModels.Base.User;

    public class BaseUsersService : BaseService
    {
        private readonly ISanitizer sanitizer;

        public BaseUsersService(IUnitOfWorkData data, ISanitizer sanitizer)
            : base(data)
        {
            this.sanitizer = sanitizer;
        }

        public IQueryable<User> GetProfileById(string userId)
        {
            var user = this.Data
                .Users
                .All()
                .Where(u => u.Id == userId);

            return user;
        }

        public void Edit(User model, BaseUserEditViewModel viewModel)
        {
            if (viewModel.InfoContent == null)
            {
                model.InfoContent = viewModel.InfoContent;
            }
            else
            {
                model.InfoContent = this.sanitizer.Sanitize(viewModel.InfoContent);
            }

            model.Email = viewModel.Email;
            model.FirstName = viewModel.FirstName;
            model.LastName = viewModel.LastName;
            this.UpdateUserImage(model);

            this.Data.SaveChanges();
        }

        private void UpdateUserImage(User model)
        {
            var photo = WebImage.GetImageFromRequest();
            if (photo != null)
            {
                photo.Resize(width: GlobalConstants.UserImageWidth, height: GlobalConstants.UserImageHeight,
                    preserveAspectRatio: false, preventEnlarge: false);
                var data = photo.GetBytes();

                if (model.UserImage != null)
                {
                    model.UserImage.Content = data;
                    model.UserImage.FileExtension = photo.ImageFormat;
                }
                else
                {
                    model.UserImage = new UserImage
                    {
                        UserId = model.Id,
                        Content = data,
                        FileExtension = "jpg"
                    };
                }
            }
        }
    }
}