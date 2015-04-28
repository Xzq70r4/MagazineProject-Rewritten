namespace MagazineProject.Web.Models.Area.Admin.InputViewModels.SiteConstant
{
    using System.ComponentModel.DataAnnotations;

    using MagazineProject.Data.Models;
    using MagazineProject.Web.Infrastructure.Mapping;

    public class AdminEditSiteConstantViewModel : IMapFrom<SiteConstant>
    {
        public int Id { get; set; }

        [UIHint("Integer")]
        [Range(0, 16)]
        public int Value { get; set; }

        public string Description { get; set; }
    }
}
