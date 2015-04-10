namespace MagazineProject.Services.Common
{
    using MagazineProject.Data.Models;

    public interface IImagesService
    {
        SliderPostCoverImage GetSliderPostCoverImageById(int id);

        ThumbnailPostCoverImage GetThumbnailPostCoverImageById(int id);

        UserImage GetUserImageById(string id);
    }
}