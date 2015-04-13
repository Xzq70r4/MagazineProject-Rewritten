namespace MagazineProject.Web.Models.Area.Users.UserComments
{
    using AutoMapper;

    using MagazineProject.Data.Models;
    using MagazineProject.Web.Models.Base;

    public class UserCommentViewModel : BaseCommentViewModel
    {
        public int PostId { get; set; }

        public override void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, UserCommentViewModel>()
                    .ForMember(c => c.AuthorName, opt => opt.MapFrom(c => c.Author.UserName))
                    .ForMember(c => c.AuthorId, opt => opt.MapFrom(c => c.AuthorId))
                    .ForMember(c => c.PostId, opt => opt.MapFrom(c => c.PostId))
                    .ForMember(c => c.TimeCreated, opt => opt.MapFrom(c => c.CreatedOn));
        }
    }
}