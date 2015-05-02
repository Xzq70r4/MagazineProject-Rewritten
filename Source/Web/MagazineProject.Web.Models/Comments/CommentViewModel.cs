namespace MagazineProject.Web.Models.Comments
{
    using AutoMapper;

    using MagazineProject.Data.Models;
    using MagazineProject.Web.Infrastructure.Mapping;
    using MagazineProject.Web.Models.Base;

    public class CommentViewModel : BaseCommentViewModel, IMapFrom<Comment>, IHaveCustomMappings
    {
        public virtual void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(c => c.AuthorName, opt => opt.MapFrom(c => c.Author.UserName))
                .ForMember(c => c.AuthorId, opt => opt.MapFrom(c => c.AuthorId)).ForMember(c => c.TimeCreated, opt => opt.MapFrom(c => c.CreatedOn));
        }
    }
}