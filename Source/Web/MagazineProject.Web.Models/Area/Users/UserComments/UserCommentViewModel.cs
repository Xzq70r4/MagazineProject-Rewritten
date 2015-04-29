namespace MagazineProject.Web.Models.Area.Users.UserComments
{
    using AutoMapper;

    using MagazineProject.Data.Models;
    using MagazineProject.Web.Infrastructure.Mapping;
    using MagazineProject.Web.Models.Base;
    using MagazineProject.Web.Models.Comments;

    public class UserCommentViewModel : BaseCommentViewModel, IHaveCustomMappings
    {
        public int PostId { get; set; }

        public string PostTitle { get; set; }

        public override void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, UserCommentViewModel>()
                .ForMember(c => c.PostTitle, opt => opt.MapFrom(c => c.Post.Title));
        }
    }
}