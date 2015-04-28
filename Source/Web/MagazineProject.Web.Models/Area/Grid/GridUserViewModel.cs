namespace MagazineProject.Web.Models.Area.Grid
{
    using System;

    using AutoMapper;

    using MagazineProject.Data.Models;
    using MagazineProject.Web.Infrastructure.Mapping;

    public class GridUserViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public DateTime TimeCreated { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<User, GridUserViewModel>()
               .ForMember(m => m.TimeCreated, opt => opt.MapFrom(u => u.CreatedOn))
               .ReverseMap();
        }
    }
}
