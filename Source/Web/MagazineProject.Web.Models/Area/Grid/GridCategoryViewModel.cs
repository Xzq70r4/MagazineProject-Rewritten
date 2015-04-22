namespace MagazineProject.Web.Models.Area.Grid
{
    using System.ComponentModel.DataAnnotations;

    using MagazineProject.Data.Models;
    using MagazineProject.Web.Infrastructure.Mapping;

    public class GridCategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Hidden")]
        public bool IsHidden { get; set; }
    }
}
