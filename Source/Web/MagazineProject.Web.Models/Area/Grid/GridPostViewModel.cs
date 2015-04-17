namespace MagazineProject.Web.Models.Area.Grid
{
    using System;

    using AutoMapper;

    using MagazineProject.Data.Common.Model;
    using MagazineProject.Data.Models;
    using MagazineProject.Web.Infrastructure.Mapping;

    public class GridPostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Category { get; set; }

        public Status Status { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Post, GridPostViewModel>()
                .ForMember(p => p.Title, opts => opts.MapFrom(p => p.Title))
                .ForMember(p => p.CreatedOn, opts => opts.MapFrom(p => p.CreatedOn))
                .ForMember(p => p.Status, opts => opts.MapFrom(p => p.Status))
                .ForMember(p => p.Category, opts => opts.MapFrom(p => p.Category.Name));
        }
    }
}