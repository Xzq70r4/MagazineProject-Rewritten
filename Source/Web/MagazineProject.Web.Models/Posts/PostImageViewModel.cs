namespace MagazineProject.Web.ViewModels.Posts
{
    using MagazineProject.Data.Models;
    using MagazineProject.Web.Infrastructure.Mapping;

    public class PostImageViewModel : IMapFrom<PostImage>
    {
        public int Id { get; set; }
    }
}