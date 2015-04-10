namespace MagazineProject.Web.Models.Posts
{
    using MagazineProject.Web.Infrastructure.Mapping;

    public class PostCoverViewModel : IMapFrom<PostCoverViewModel>
    {
        public int Id { get; set; }
    }
}