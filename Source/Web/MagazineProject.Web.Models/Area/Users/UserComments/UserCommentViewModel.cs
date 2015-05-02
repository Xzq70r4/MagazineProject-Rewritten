namespace MagazineProject.Web.Models.Area.Users.UserComments
{
    using AutoMapper;

    using MagazineProject.Data.Models;
    using MagazineProject.Web.Infrastructure.Mapping;
    using MagazineProject.Web.Models.Base;

    public class UserCommentViewModel : BaseCommentViewModel, IMapFrom<Comment>, IHaveCustomMappings
    {
        public int PostId { get; set; }

        public string PostTitle { get; set; }

        public virtual void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, UserCommentViewModel>()
                .ForMember(c => c.AuthorName, opt => opt.MapFrom(c => c.Author.UserName))
                .ForMember(c => c.AuthorId, opt => opt.MapFrom(c => c.AuthorId))
                .ForMember(c => c.TimeCreated, opt => opt.MapFrom(c => c.CreatedOn))
                .ForMember(c => c.PostTitle, opt => opt.MapFrom(c => c.Post.Title));
        }
    }
}