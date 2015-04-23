namespace MagazineProject.Web.Models.Area.Grid
{
    using System.ComponentModel.DataAnnotations;

    using MagazineProject.Data.Models;
    using MagazineProject.Web.Infrastructure.Mapping;

    public class GridSiteConstantViewModel : IMapFrom<SiteConstant>
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public string Description { get; set; }
    }
}
