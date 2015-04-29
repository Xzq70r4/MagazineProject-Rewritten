namespace MagazineProject.Web.Models.Base
{
    using AutoMapper;

    using MagazineProject.Data.Models;
    using MagazineProject.Web.Infrastructure.Mapping;
    using MagazineProject.Web.Models.Home;

    public class BasePostViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}