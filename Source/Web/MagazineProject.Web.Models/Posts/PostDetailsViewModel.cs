namespace MagazineProject.Web.Models.Posts
{
    using System;

    using AutoMapper;

    using MagazineProject.Data.Models;
    using MagazineProject.Web.Infrastructure.Mapping;

    public class PostDetailsViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorName { get; set; }

        public string AuthorId { get; set; }

        public string CategoryName { get; set; }

        public DateTime TimeCreated { get; set; }

        public string UrlVideo { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Post, PostDetailsViewModel>()
                .ForMember(m => m.CategoryName, opt => opt.MapFrom(p => p.Category.Name))
                .ForMember(m => m.AuthorName, opt => opt.MapFrom(p => p.Author.UserName))
                .ForMember(m => m.AuthorId, opt => opt.MapFrom(p => p.AuthorId))
                .ForMember(m => m.TimeCreated, opt => opt.MapFrom(p => p.CreatedOn))
                .ReverseMap();
        }
    }
}