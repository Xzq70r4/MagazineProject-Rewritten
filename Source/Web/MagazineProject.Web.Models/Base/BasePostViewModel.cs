namespace MagazineProject.Web.Models.Base
{
    using AutoMapper;

    using MagazineProject.Data.Models;
    using MagazineProject.Web.Infrastructure.Mapping;
    using MagazineProject.Web.Models.Home;

    public class BasePostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string PostTitle { get; set; }

        //public int CategoryId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(m => m.PostTitle, opt => opt.MapFrom(p => p.Title))
                .ReverseMap();
        }
    }
}