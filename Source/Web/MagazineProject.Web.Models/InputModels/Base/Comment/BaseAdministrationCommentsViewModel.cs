namespace MagazineProject.Web.Models.InputModels.Base.Comment
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using MagazineProject.Data.Common.Model;
    using MagazineProject.Data.Models;
    using MagazineProject.Web.Infrastructure.Mapping;

    //Administration is common for Moderator and Admin
    public class BaseAdministrationCommentsViewModel : IMapFrom<Comment>
    {
        [AllowHtml]
        [Required]
        [MinLength(20)]
        [MaxLength(25000)]
        [DataType("tinymce_full")]
        public string Content { get; set; }

        [UIHint("Enum")]
        public Status Status { get; set; }
    }
}
