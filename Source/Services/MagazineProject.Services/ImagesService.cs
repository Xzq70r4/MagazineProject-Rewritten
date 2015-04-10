namespace MagazineProject.Services
{
    using MagazineProject.Data.Models;
    using MagazineProject.Data.UnitOfWork;
    using MagazineProject.Services.Common;

    /// <summary>
    /// The images service.
    /// </summary>
    public class ImagesService : BaseService, IImagesService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImagesService"/> class.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        public ImagesService(IUnitOfWorkData data)
            : base(data)
        {
        }

        /// <summary>
        /// The get slider post cover image by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="SliderPostCoverImage"/>.
        /// </returns>
        public SliderPostCoverImage GetSliderPostCoverImageById(int id)
        {
            var sliderCoverImage = this.Data.SliderPostCoverImages.GetById(id);

            return sliderCoverImage;
        }

        /// <summary>
        /// The get thumbnail post cover image by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ThumbnailPostCoverImage"/>.
        /// </returns>
        public ThumbnailPostCoverImage GetThumbnailPostCoverImageById(int id)
        {
            var thumbnailPostCoverImage = this.Data.ThumbnailPostCoverImages.GetById(id);

            return thumbnailPostCoverImage;
        }

        /// <summary>
        /// The get user image by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="UserImage"/>.
        /// </returns>
        public UserImage GetUserImageById(string id)
        {
            var userImage = this.Data.UserImages.GetById(id);

            return userImage;
        }
    }
}
