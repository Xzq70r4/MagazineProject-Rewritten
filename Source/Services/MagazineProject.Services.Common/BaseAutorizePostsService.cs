namespace MagazineProject.Services.Common
{
    using System.Web.Helpers;

    using MagazineProject.Data.Models;
    using MagazineProject.Data.UnitOfWork;
    using MagazineProject.Web.Models.InputModels.Base.Post;

    public class BaseAutorizePostsService : BaseService
    {
        public BaseAutorizePostsService(IUnitOfWorkData data)
            : base(data)
        {
        }

        //TODO: Magic Number ?
        protected void UpdatedSliderPostCoverImage(Post model, BaseAutorizationPostViewModel viewModel, WebImage image)
        {
            if (image != null)
            {
                image.Resize(width: 1200, height: 500, preserveAspectRatio: false, preventEnlarge: false);
                byte[] data = image.GetBytes();
                model.SliderCoverImage.PostId = model.Id;
                model.SliderCoverImage.Content = data;
                model.SliderCoverImage.FileExtension = image.ImageFormat;
            }
        }

        protected void UpdatedThumbnailPostCoverImage(
            Post model,
            BaseAutorizationPostViewModel viewModel,
            WebImage image)
        {

            if (image != null)
            {
                image.Resize(width: 350, height: 200, preserveAspectRatio: false, preventEnlarge: false);
                byte[] data = image.GetBytes();

                model.ThumbnailCoverImage.PostId = model.Id;
                model.ThumbnailCoverImage.Content = data;
                model.ThumbnailCoverImage.FileExtension = image.ImageFormat;

            }
        }

    }
}