namespace MagazineProject.Web.Models.Area.Grid
{
    using System;

    using AutoMapper;

    using MagazineProject.Data.Common.Model;
    using MagazineProject.Data.Models;
    using MagazineProject.Web.Infrastructure.Mapping;

    public class GridCommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string AuthorName { get; set; }

        public string PostTitle { get; set; }

        public DateTime CreatedOn { get; set; }

        public Status Status { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, GridCommentViewModel>()
                .ForMember(p => p.AuthorName, opts => opts.MapFrom(p => p.Author.UserName))
                .ForMember(p => p.PostTitle, opts => opts.MapFrom(p => p.Post.Title));
        }
    }
}
