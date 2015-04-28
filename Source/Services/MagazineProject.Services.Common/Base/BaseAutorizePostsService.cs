namespace MagazineProject.Services.Common.Base
{
    using System.Web.Helpers;

    using MagazineProject.Common;
    using MagazineProject.Data.Models;
    using MagazineProject.Data.UnitOfWork;
    using MagazineProject.Web.Models.InputModels.Base.Post;

    public class BaseAutorizePostsService : BaseService
    {
        public BaseAutorizePostsService(IUnitOfWorkData data)
            : base(data)
        {
        }

        protected void UpdatedSliderPostCoverImage(Post model, BaseAutorizationPostViewModel viewModel, WebImage image)
        {
            if (image != null)
            {
                image.Resize(width: GlobalConstants.SliderPostCoverImageWidth, height: GlobalConstants.SliderPostCoverImageHigth,
                    preserveAspectRatio: false, preventEnlarge: false);
                byte[] data = image.GetBytes();
                model.SliderCoverImage.PostId = model.Id;
                model.SliderCoverImage.Content = data;
                model.SliderCoverImage.FileExtension = image.ImageFormat;
            }
        }

        protected void UpdatedThumbnailPostCoverImage(Post model, BaseAutorizationPostViewModel viewModel, WebImage image)
        {
            if (image != null)
            {
                image.Resize(width: GlobalConstants.ThumbnailPostCoverImageWidth, height: GlobalConstants.ThumbnailPostCoverImageHeight,
                    preserveAspectRatio: false, preventEnlarge: false);
                byte[] data = image.GetBytes();

                model.ThumbnailCoverImage.PostId = model.Id;
                model.ThumbnailCoverImage.Content = data;
                model.ThumbnailCoverImage.FileExtension = image.ImageFormat;
            }
        }
    }
}