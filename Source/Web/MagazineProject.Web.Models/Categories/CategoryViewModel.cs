namespace MagazineProject.Web.Models.Categories
{
    using AutoMapper;

    using MagazineProject.Data.Models;
    using MagazineProject.Web.Infrastructure.Mapping;

    public class CategoryViewModel : IMapFrom<Category>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Category, CategoryViewModel>()
                .ForMember(m => m.Name, opt => opt.MapFrom(c => c.Name))
                .ReverseMap();
        }
    }
}