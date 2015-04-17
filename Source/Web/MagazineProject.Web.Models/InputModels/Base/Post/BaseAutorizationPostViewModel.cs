namespace MagazineProject.Web.Models.InputModels.Base.Post
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using MagazineProject.Data.Models;
    using MagazineProject.Web.Infrastructure.Mapping;

    public class BaseAutorizationPostViewModel : IMapFrom<Post>
    {
        [Required]
        [MinLength(10)]
        [MaxLength(150)]
        [UIHint("SingleLineText")]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        [MinLength(1500)]
        [MaxLength(25000)]
        [UIHint("tinymce_add_post")]
        public string Content { get; set; }

        [Display(Name = "Category")]
        [UIHint("DropDownList")]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }


        //[Required]
        //[Display(Name = "Cover Image")]
        //[UIHint("UploadImage")]
        //[FileTypes("jpg,jpeg,png")]
        //[FileSize(4194304)]
        //public virtual HttpPostedFileBase UploadedImage { get; set; }
    }
}