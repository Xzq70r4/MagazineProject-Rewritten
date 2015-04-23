namespace MagazineProject.Web.Controllers
{
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;

    using MagazineProject.Common;
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

        public ActionResult SliderPostCoverImage(int id)
        {
            var image = this.images.GetSliderPostCoverImageById(id);
            if (image == null)
            {
                throw new HttpException(404, "Image not found");
            }

            return this.File(image.Content, "image/" + image.FileExtension);
        }

        public ActionResult ThumbnailPostCoverImage(int id)
        {
            var image = this.images.GetThumbnailPostCoverImageById(id);
            if (image == null)
            {
                throw new HttpException(404, "Image not found");
            }

            return this.File(image.Content, "image/" + image.FileExtension);
        }

        public ActionResult UserImage(string id)
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