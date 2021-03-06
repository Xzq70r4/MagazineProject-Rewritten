﻿namespace MagazineProject.Web.Models.InputModels.Base.Category
{
    using System.ComponentModel.DataAnnotations;

    using MagazineProject.Data.Models;
    using MagazineProject.Web.Infrastructure.Mapping;
    using MagazineProject.Web.Infrastructure.ValidationAttribute;

    //Administration is common for Moderator and Admin
    public class BaseAdministrationCategoryViewModel : IMapFrom<Category>
    {
        [Required]
        [MinLength(2)]
        [MaxLength(10)]
        [UIHint("SingleLineText")]
        [DoesNotContain("&")]
        public string Name { get; set; }

        [Display(Name = "Hidden")]
        [UIHint("Boolean")]
        public bool IsHidden { get; set; }
    }
}
