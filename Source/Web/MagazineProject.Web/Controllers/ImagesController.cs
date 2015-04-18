namespace MagazineProject.Web.Controllers
{
    using System.Web;
    using System.Web.Mvc;

    using MagazineProject.Services.Common;
    using MagazineProject.Web.Controllers.Base;

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

        //TODO:check post image 
        public ActionResult UserImage(string id)
        {
            var image = this.images.GetUserImageById(id);
            if (image == null)
            {
                throw new HttpException(404, "Image not found");
            }

            return this.File(image.Content, "image/" + image.FileExtension);
        }
    }
}