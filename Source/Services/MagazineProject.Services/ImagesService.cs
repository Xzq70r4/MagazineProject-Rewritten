namespace MagazineProject.Services
{
    using MagazineProject.Data.Models;
    using MagazineProject.Data.UnitOfWork;
    using MagazineProject.Services.Common;
    using MagazineProject.Services.Common.Base;

    public class ImagesService : BaseService, IImagesService
    {
        public ImagesService(IUnitOfWorkData data)
            : base(data)
        {
        }

        public SliderPostCoverImage GetSliderPostCoverImageById(int id)
        {
            var sliderCoverImage = this.Data.SliderPostCoverImages.GetById(id);

            return sliderCoverImage;
        }

        public ThumbnailPostCoverImage GetThumbnailPostCoverImageById(int id)
        {
            var thumbnailPostCoverImage = this.Data.ThumbnailPostCoverImages.GetById(id);

            return thumbnailPostCoverImage;
        }

        public UserImage GetUserImageById(string id)
        {
            var userImage = this.Data.UserImages.GetById(id);

            return userImage;
        }
    }
}
