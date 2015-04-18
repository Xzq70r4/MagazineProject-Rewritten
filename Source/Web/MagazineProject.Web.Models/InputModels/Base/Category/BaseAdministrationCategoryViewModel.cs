namespace MagazineProject.Web.Models.InputModels.Base.Category
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using MagazineProject.Data.Models;
    using MagazineProject.Web.Infrastructure.Mapping;

    public class BaseAdministrationCategoryViewModel : IMapFrom<Category>
    {
        [Required]
        [MinLength(2)]
        [MaxLength(10)]
        [UIHint("SingleLineText")]
        public string Name { get; set; }

        [Display(Name = "Hidden")]
        [UIHint("Boolean")]
        public bool IsHidden { get; set; }
    }
}
