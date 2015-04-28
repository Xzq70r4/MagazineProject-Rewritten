namespace MagazineProject.Web.Controllers
{
    using System.Web;
    using System.Web.Mvc;

    using MagazineProject.Services.Common;
    using MagazineProject.Web.Controllers.Base;
    using MagazineProject.Web.Infrastructure.Extensions;

    public class ImagesController : BaseController
    {
        private readonly IImagesService images;

        public ImagesController(IImagesService images)
        {
            this.images = images;
        }

        [OutputCache(CacheProfile = "LongLived")]
        public FileContentResult SliderPostCoverImage(int id)
        {
            var image = this.images.GetSliderPostCoverImageById(id);
            if (image == null)
            {
                throw new HttpException(404, "Image not found");
            }

            return this.File(image.Content, "image/" + image.FileExtension);
        }

        [OutputCache(CacheProfile = "LongLived")]
        public FileContentResult ThumbnailPostCoverImage(int id)
        {
            var image = this.images.GetThumbnailPostCoverImageById(id);
            if (image == null)
            {
                throw new HttpException(404, "Image not found");
            }

            return this.File(image.Content, "image/" + image.FileExtension);
        }

        public FileContentResult UserImage(string id)
        {
            var image = this.images.GetUserImageById(id);
            if (image == null)
            {
                var file = ConvertImage.ToBytes("/Images/default-user-img.jpg");

                return this.File(file, "image/jpg");
            }

            return this.File(image.Content, "image/" + image.FileExtension);
        }

       [OutputCache(CacheProfile = "ShortLived")]
        public FileContentResult CommentUserImage(string id)
        {
            var image = this.images.GetUserImageById(id);
            if (image == null)
            {
                var file = ConvertImage.ToBytes("/Images/default-user-img.jpg");

                return this.File(file, "image/jpg");
            }

            return this.File(image.Content, "image/" + image.FileExtension);
        }
    }
}