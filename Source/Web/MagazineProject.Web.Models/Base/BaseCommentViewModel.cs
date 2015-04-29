namespace MagazineProject.Web.Models.Base
{
    using System;

    using AutoMapper;

    using MagazineProject.Data.Models;
    using MagazineProject.Web.Infrastructure.Mapping;
    using MagazineProject.Web.Models.Comments;

    public class BaseCommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string AuthorName { get; set; }

        public string AuthorId { get; set; }

        public string Content { get; set; }

        public DateTime TimeCreated { get; set; }

        public virtual void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, BaseCommentViewModel>()
                .ForMember(c => c.AuthorName, opt => opt.MapFrom(c => c.Author.UserName))
                .ForMember(c => c.TimeCreated, opt => opt.MapFrom(c => c.CreatedOn));
        }
    }
}